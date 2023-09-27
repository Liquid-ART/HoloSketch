namespace XRProtoUIToolKit
{
    using UnityEngine;

    public interface ITweenAnimation
    {
        Transform Transform { get; set; }
        void Init(GameObject _thisObj);
        TweenAnimation Play();
        TweenAnimation PlayBackwards();
        TweenAnimation SetDelay(float delay);
        TweenAnimation SetDuration(float duration);
        TweenAnimation OnComplete(TweenAnimationCallback OnComplete);
        void AddToOnCompleteCallback(TweenAnimationCallback Callback);
        void StopAnimation();
        bool IsPlaying { get; }

    }
}
