namespace HoloSketch
{
    public interface IAudioManager
    {
        bool IsActive { get; set; }
        void PlayHoverSound();
        void PlayClickSound();
      //  void PlayTransitionSound();

    }
}

