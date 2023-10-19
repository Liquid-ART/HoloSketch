using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloSketch
{
    [ExecuteInEditMode]
    public class DMMScaler : MonoBehaviour
    {
        private DMMGroup dMMGroup;
        //test
        public float currentDistance;

        void Start()
        {
            Init();
        }

        void Init()
        {
            dMMGroup = GetComponentInParent<DMMGroup>();
        }

        void SetNewScale(Transform viewPoint)
        {
            float distance = Vector3.Distance(transform.position, viewPoint.position);
            currentDistance = distance;
            float newScale = Mathf.Clamp(distance, dMMGroup.ScaleClamp.x, dMMGroup.ScaleClamp.y);
            transform.localScale = new Vector3(newScale, newScale, newScale);            
        }

        void Update()
        {
            if (dMMGroup.IsActive && dMMGroup.UpdateInGame)            
                    SetNewScale(dMMGroup.expectedViewPoint);
            
        }

        void OnUpdateGizmo()
        {
            if (dMMGroup.IsActive)
                SetNewScale(dMMGroup.expectedViewPoint);
        }

       /* Vector3 GetScreenCenter(RectTransform[] childRect)
        {
            Vector3[][] corners = new Vector3[childRect.Length][];

            //fill corners
            for (int i = 0; i < corners.Length; i++)
            {
                childRect[i].GetLocalCorners(corners[i]);
            }

            //get top left corner
            float topLeftlatestResultX = 0;
            float topLeftlatestResultY = 0;
            foreach (Vector3[] array in corners)
            {
                if (array[2].x < topLeftlatestResultX)
                    topLeftlatestResultX = array[2].x;
                if (array[2].y > topLeftlatestResultY)
                    topLeftlatestResultY = array[2].y;
            }
            Vector3 topLeftCorner = new Vector3(topLeftlatestResultX, topLeftlatestResultY, rectTransform.position.z);

            //get bottom right corner
            float bottomRightlatestResultX = 0;
            float bottomRightlatestResultY = 0;
            foreach (Vector3[] array in corners)
            {
                if (array[4].x > bottomRightlatestResultX)
                    bottomRightlatestResultX = array[2].x;
                if (array[4].y < bottomRightlatestResultY)
                    bottomRightlatestResultY = array[2].y;
            }
            Vector3 bottomLeftCorner = new Vector3(bottomRightlatestResultX, bottomRightlatestResultY, rectTransform.position.z);

            //get center
            Vector3 screenCeneter = Vector3.Lerp(topLeftCorner, bottomLeftCorner, 0.5f);
            return screenCeneter;

        }

*/
        }
    }

