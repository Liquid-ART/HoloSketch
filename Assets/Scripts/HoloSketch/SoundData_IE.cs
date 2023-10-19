using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections.Generic;
namespace HoloSketch
{
    [CreateAssetMenu(menuName = "SoundData/InteractableElement", fileName = "NewInteractableElementSoundData")]
    public class SoundData_IE : ScriptableObject
    {
        public Sound hover;
        public Sound click;
        public Sound transition;
    }
}
