using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace XRProtoUIToolKit
{
    public class UIElementDefaultAnims : AnimationData, IAnimationData_UI_Element
    {
        public ITweenAnimation Show { get; set; }
        [HideInInspector]
        public CanvasGroup canvasGroup;
        public bool HasShowAnimation = true;
        public float scaleHide = 0.8f;



        public virtual void Init()
        {
            canvasGroup = GetComponent<CanvasGroup>();

            Show = new DefaultButtonShow();
            Show.Init(gameObject);
        }
        void Awake()
        {
            Init();
        }

    }

    public class DefaultButtonShow : TweenAnimation
    {

        protected UIElementDefaultAnims animData;
        public override void Init(GameObject _thisObj)
        {
            base.Init(_thisObj);
            animData = thisObj.GetComponent<UIElementDefaultAnims>();
        }

        public override TweenAnimation Play()
        {

            if (!animData.HasShowAnimation)
            {
                animCache.OnCompleteCallback();
                return this;
            }

            animCache.StartCallback = () =>
            {

                NewTween(animData.canvasGroup.DOFade(1, CurrentCache.Duration).SetDelay(CurrentCache.Delay).SetEase(CurrentCache.EasePlay)
                                .SetEase(CurrentCache.EasePlay)); ;


                NewTween(Transform.DOScale(1, CurrentCache.Duration).SetDelay(CurrentCache.Delay).SetEase(CurrentCache.EasePlay)
                                .SetEase(CurrentCache.EasePlay).OnComplete(() => {
                                    CurrentCache.OnCompleteCallback();
                                })); ;

            };

            RunAnimation();

            return this;
        }



        public override TweenAnimation PlayBackwards()
        {

            if (!animData.HasShowAnimation)
            {
                animCache.OnCompleteCallback();
                return this;
            }

            animCache.StartCallback = () =>
            {

                NewTween(animData.canvasGroup.DOFade(0, CurrentCache.Duration).SetDelay(CurrentCache.Delay).SetEase(CurrentCache.EasePlay)
                                .SetEase(CurrentCache.EasePlay)); ;


                NewTween(Transform.DOScale(animData.scaleHide, CurrentCache.Duration).SetDelay(CurrentCache.Delay).SetEase(CurrentCache.EasePlay)
                                .SetEase(CurrentCache.EasePlay).OnComplete(() => {
                                    CurrentCache.OnCompleteCallback();
                                })); ;
            };

            RunAnimation();

            return this;

        }
    }

}

