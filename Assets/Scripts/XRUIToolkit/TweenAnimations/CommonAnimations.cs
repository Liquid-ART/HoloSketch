using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace XRProtoUIToolKit
{

    public class CommonAnimData : AnimationData
    {
        [HideInInspector]
        public CanvasGroup canvasGroup;
        [HideInInspector]
        public ColorPallette colorPallette;
    }

    public class ShowAnimation : TweenAnimation
    {

        protected CommonAnimData animData;
        public override void Init(GameObject _thisObj)
        {
            base.Init(_thisObj);
            animData = thisObj.GetComponent<CommonAnimData>();
        }

        public override TweenAnimation Play()
        {

            animCache.StartCallback = () =>
            {

                NewTween(animData.canvasGroup.DOFade(1, CurrentCache.Duration).SetDelay(CurrentCache.Delay)
                                .SetEase(CurrentCache.EasePlay));

                NewTween(Transform.DOScale(1f, CurrentCache.Duration).SetDelay(CurrentCache.Delay)
                            .SetEase(CurrentCache.EasePlay).OnComplete(() => {
                                animData.canvasGroup.interactable = true; animData.canvasGroup.blocksRaycasts = true;
                                CurrentCache.OnCompleteCallback(); }));
            };

            RunAnimation();

            return this;
        }



        public override TweenAnimation PlayBackwards()
        {

            animCache.StartCallback = () =>
            {

                if (animData == null) Debug.Log("ShowAnimation animData == null");
                NewTween(animData.canvasGroup.DOFade(0, CurrentCache.Duration).SetDelay(CurrentCache.Delay)
                            .SetEase(CurrentCache.EasePlayBackwards));

                NewTween(Transform.DOScale(0.8f, CurrentCache.Duration).SetDelay(CurrentCache.Delay)
                        .SetEase(CurrentCache.EasePlayBackwards).OnComplete(() => {
                            animData.canvasGroup.interactable = false; animData.canvasGroup.blocksRaycasts = false;
                            CurrentCache.OnCompleteCallback(); }));
            };

            RunAnimation();

            return this;

        }
    }




    public class EmptyAnimation : TweenAnimation
    {
        public override TweenAnimation Play()
        {
            animCache.OnCompleteCallback();
            return this;
        }

        public override TweenAnimation PlayBackwards()
        {
            animCache.OnCompleteCallback();
            return this;
        }

    }
}
