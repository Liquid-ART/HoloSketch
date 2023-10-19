using UnityEngine.Audio;
using UnityEngine;
using System;

namespace HoloSketch
{





    public class AudioManager : MonoBehaviour, IAudioManager, IInteractableElementDepended
    {

        [field: SerializeField]
        public bool IsActive { get; set; }

        /* [SerializeField]
         private SoundData_IE soundData;*/

        public Sound hover;
        public Sound click;
       // public Sound transition;

        private AudioSource audioSource;

        void Awake()
        {
            Init();
        }

        private void Init()
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        public void PlayHoverSound()
        {
            Play(hover);
        }

        public void PlayClickSound()
        {
            Play(click);
        }



       protected void Play(Sound sound)
        {
            if (IsActive)
            {
                audioSource.clip = sound.clip;
                audioSource.volume = sound.volume;
                audioSource.pitch = sound.pitch;
                audioSource.loop = sound.loop;
                audioSource.spatialBlend = sound.spatial;
                audioSource.Play();
            }

        }

        //IInteractableElementDepended

        public void OnPointerClick()
        {
            PlayClickSound();
        }

        public void OnPointerDown()
        {

        }

        public void OnPointerEnter()
        {
            PlayHoverSound();
        }

        public void OnPointerExit()
        {

        }

        public void OnPointerUp()
        {

        }
    }


    [System.Serializable]
    public class Sound
    {
        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume = 1;
        [Range(0.1f, 3f)]
        public float pitch = 1;
        public bool loop;
        [Range(0f, 1f)]
        public float spatial = 1;

        [HideInInspector]
        public AudioSource source;
    }

    //-----------------
    public class SoundPlayer
    {
        int lastIndex;

        public void Play(int index, Sound[] sounds, GameObject gameObj)
        {
            sounds[index].source = gameObj.GetComponent<AudioSource>();
            sounds[index].source.clip = sounds[index].clip;
            sounds[index].source.volume = sounds[index].volume;
            sounds[index].source.pitch = sounds[index].pitch;
            sounds[index].source.loop = sounds[index].loop;
            sounds[index].source.spatialBlend = sounds[index].spatial;
            sounds[index].source.Play();
        }



        public void PlayRandom(Sound[] sounds, GameObject gameObj)
        {
            int index = UnityEngine.Random.Range(0, sounds.Length);
            if (index == lastIndex)
            {
                index = UnityEngine.Random.Range(0, sounds.Length);
            }
            lastIndex = index;

            Play(index, sounds, gameObj);

        }
    }
}

