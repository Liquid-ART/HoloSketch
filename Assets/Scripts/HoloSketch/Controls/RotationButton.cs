using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace HoloSketch
{
    public class RotationButton : InteractableElement
    {
        [SerializeField]
        private Transform rotationInput;
        [SerializeField]
        private float sensitivity = 1;
        [SerializeField]
        private Transform sphereTransform;

        public override void Init()
        {
            base.Init();
        }

        public override void OnPointerDown()
        {
            base.OnPointerDown();
            GlobalEventManager.DisableAllUiInteraction(false);

        }

        public override void OnPointerUp()
        {
            base.OnPointerUp();
            GlobalEventManager.EnableAllUiInteraction();
            lastPosition = Vector2.zero;
        }

        private Vector2 lastPosition;

        Tween rotationTween;
        public void Update()
        {

            if (IsPointerDown)
            {

                Vector2 rotInputVector = rotationInput.position;
                if (rotationTween != null) rotationTween.Kill();

                float inputDifferenceX = 0;
                float inputDifferenceY = 0;
                if(lastPosition != Vector2.zero)
                {
                    inputDifferenceX = (rotInputVector.x - lastPosition.x) * sensitivity;
                    //inputDifferenceX = inputDifferenceX - (inputDifferenceX * 2);

                    inputDifferenceY = (rotInputVector.y - lastPosition.y) * (sensitivity / 2) /*- (inputDifferenceY * 2)*/;
                    inputDifferenceY = inputDifferenceY - (inputDifferenceY * 2);
                }

               // if (inputDifferenceY > 0) inputDifferenceY = inputDifferenceY - inputDifferenceY * 2;
               // if (inputDifferenceY < 0) inputDifferenceY = inputDifferenceY + inputDifferenceY * 2;

                rotationTween = sphereTransform.DORotate(new Vector3(inputDifferenceY, inputDifferenceX, 0), 1f, RotateMode.WorldAxisAdd);
                lastPosition = new Vector2(rotationInput.position.x, rotationInput.position.y);
                
                
               // Debug.Log("CheckboxPlanet if (IsPointerDown)" + new Vector2(inputDifferenceX, inputDifferenceY));
               // Debug.Log("rotInputVector)" + new Vector2(rotInputVector.x , rotInputVector.y));
              //  Debug.Log("lastPosition" + lastPosition);
            }
        }

    }
}


