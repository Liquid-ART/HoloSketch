using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace HoloSketch
{

    public abstract class AnimationData : MonoBehaviour
    {
        public float duration = 0.5f;
        public float delay = 0f;
        public AnimBehaviour behaviour = AnimBehaviour.KillPreviousAndPlay;
        public Ease EasePlay = Ease.InSine;
        public Ease EasePlayBackwards = Ease.OutSine;
    }

    [Serializable]
    public class TweenAnimationCache
    {
        public TweenAnimationCallback StartCallback;
        public TweenAnimationCallback OnCompleteCallback;
     //   public Transform Transform;
        public List<Tween> Tweens;
        public float Delay;
        public float Duration;
        public Ease EasePlay;
        public Ease EasePlayBackwards;

        public TweenAnimationCache()
        {
            EasePlay = Ease.InOutSine;
            Tweens = new List<Tween>();
            StartCallback = () => { Debug.LogError("Call Null StartCallback in TweenAnimation.data"); };
            OnCompleteCallback = () => {  };
        }

      /*  public TweenAnimationData(Transform transform)
            : this()
        {
            this.Transform = transform;

        }*/

        public TweenAnimationCache Clone()
        {
            TweenAnimationCache cash = (TweenAnimationCache)this.MemberwiseClone();
            cash.Tweens = new List<Tween>();
            return cash;
        }
    }

    public enum AnimBehaviour
    {
        AddToQueueIfPlaying,
        ReturnIfPlaying,
        KillPreviousAndPlay
    }

    [System.Serializable]
    public abstract class TweenAnimation : ITweenAnimation
    {


        protected GameObject thisObj;
        public Transform Transform { get; set; }
        protected TweenAnimationCache animCache;
        protected List<TweenAnimationCache> cacheList;
        protected AnimBehaviour behaviour = AnimBehaviour.KillPreviousAndPlay;
        protected AnimationData animDataBase;

        public bool IsPlaying
        {
            get
            {
                if (cacheList.Count > 0)
                    return true;
                else
                    return false;
            }

        }

        public TweenAnimationCache CurrentCache
        {
            //if ArgumentOutOfRangeException: Index was out of range. then there is 2 OnComplete callbacks in animation

            get
            {
                if (cacheList.Count > 1)
                    return cacheList[1];
                else
                    return cacheList[0];
            }
        }

        public virtual void Init(GameObject _thisObj)
        {
           // this.animData = _thisObj.GetComponent<AnimationData>();
            thisObj = _thisObj;
            Transform = thisObj.transform;
            animCache = new TweenAnimationCache();
            cacheList = new List<TweenAnimationCache>();

            animDataBase = thisObj.GetComponent<AnimationData>();
            if (animDataBase == null) Debug.Log("animData == null");
            SetDelay(animDataBase.delay);
            SetDuration(animDataBase.duration);
            animCache.EasePlay = animDataBase.EasePlay;
            animCache.EasePlayBackwards = animDataBase.EasePlayBackwards;

            behaviour = animDataBase.behaviour;


        }

        public virtual TweenAnimation Play()
        {
            return this;
        }

        public virtual TweenAnimation PlayBackwards()
        {
            return this;
        }

        public void NewTween(Tween tween)
        {
            CurrentCache.Tweens.Add(tween);
        }

        public virtual void ClearData()
        {
            float duration = animCache.Duration;
            animCache = new TweenAnimationCache();
            animCache.Duration = duration;
            animCache.OnCompleteCallback = () => { };
        }

        public virtual void RunAnimation()
        {


            animCache.OnCompleteCallback += () => {
                if (cacheList.Count == 1)
                {
                    cacheList.RemoveAt(0);
                }
            };

            cacheList.Add(animCache.Clone());

            if (behaviour == AnimBehaviour.ReturnIfPlaying)
            {
                if(cacheList.Count > 1)
                {

                    ClearData();
                    cacheList.RemoveAt(1);
                    return;
                }

                else
                {
                    cacheList[0].StartCallback();
                }
            }


            if (behaviour == AnimBehaviour.AddToQueueIfPlaying)
              {
                  if (cacheList.Count == 2)
                  {
                      Tween lastTween = cacheList[0].Tweens[cacheList[0].Tweens.Count - 1];
                      lastTween.onComplete += () => {
                          cacheList[1].StartCallback();
                          cacheList.RemoveAt(0);
                      };
                  }

                  else if (cacheList.Count > 2)
                  {
                      cacheList[cacheList.Count - 1].OnCompleteCallback += () => {
                          if (cacheList.Count > 1)
                          {
                              cacheList[1].StartCallback();
                              cacheList.RemoveAt(0);
                          }
                      };
                  }

                  else
                  {
                      cacheList[0].StartCallback();
                  }
              }

              if(behaviour == AnimBehaviour.KillPreviousAndPlay)
              {
                if (cacheList.Count > 1)
                {
                    foreach (var i in cacheList[0].Tweens)
                    {
                        i.onComplete = null;
                        i.Kill();
                    }
                    cacheList.RemoveAt(0);
                }
                cacheList[0].StartCallback();
              }
            ClearData();

        }

        public virtual void AddToOnCompleteCallback(TweenAnimationCallback Callback)
        {
            if(IsPlaying)
            {
                Tween lastTween = cacheList[0].Tweens[cacheList[0].Tweens.Count - 1];
                lastTween.onComplete += () => {
                    Callback();
                };
            }

            else
            {
                animCache.OnCompleteCallback += Callback;
            }

        }

        public virtual TweenAnimation SetDelay(float delay)
        {
            if (animCache == null) Debug.Log("SetDelay animCache == null");
            animCache.Delay = delay;
            return this;
        }

        public virtual TweenAnimation SetEase(Ease ease)
        {
            animCache.EasePlay = ease;
            animCache.EasePlayBackwards = ease;
            return this;
        }

        public virtual TweenAnimation SetDuration(float duration)
        {
            animCache.Duration = duration;
            return this;
        }

        public virtual TweenAnimation OnComplete(TweenAnimationCallback OnComplete)
        {

            animCache.OnCompleteCallback = OnComplete;

            return this;
        }


      /*  public virtual void ClearCallbacks()
        {
            data.OnCompleteCallback = () => { };
            //OnCompleteCallbackLocal = () => { };
        }*/



        public virtual void StopAnimation()
        {
           // IsPlaying = false;
           // OnAnimComplete();
            //ClearTweens();
           // ClearCallbacks();
        }



    }


}
