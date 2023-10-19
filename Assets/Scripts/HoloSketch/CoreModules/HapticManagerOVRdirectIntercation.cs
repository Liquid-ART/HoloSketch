using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Oculus.Interaction;
using Oculus.Haptics;

namespace HoloSketch
{
    public class HapticManagerOVRdirectIntercation : MonoBehaviour, IInteractableElementDepended
    {

        public bool RightControllerActive = false;

        public HapticClip hover;
        public HapticClip click;
        private HapticClipPlayer player;

        void PlayHapticClip(HapticClip clip, Oculus.Haptics.Controller controller) 
        {

            player = new HapticClipPlayer(clip);
            player.Play(controller);
        }


        public void OnPointerClick()
        {
            if (RightControllerActive)
                PlayHapticClip(click, Controller.Right);
            else
                PlayHapticClip(click, Controller.Left);

            

            //hapticAction.Execute(0, 0.1f, 1, 1, rightHand);
            // hapticAction.Execute(0.2f, 0.1f, 1, 1, rightHand);
        }

        public void OnPointerDown()
        {

        }

        public void OnPointerEnter()
        {
          //  Debug.Log("----------------HapticManager is called");
            if (RightControllerActive)
                PlayHapticClip(hover, Controller.Right);
            else
                PlayHapticClip(hover, Controller.Left);
        }

        public void OnPointerExit()
        {

        }

        public void OnPointerUp()
        {
  
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}


