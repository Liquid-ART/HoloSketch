using UnityEngine;


namespace XRProtoUIToolKit
{
    public class Loader : MonoBehaviour
    {
        public Transform[] spheres;
        public Transform controller;
        public float sizeClamp, sizeDevider;
        public bool IsActive;


        private void Update()
        {
            PlayLoader();
        }

        private void OnDrawGizmos()
        {
            PlayLoader();
        }

        private void PlayLoader()
        {
            if (IsActive)
            {
                foreach (var i in spheres)
                {
                    float distance = Vector3.Distance(i.position, controller.position);
                    float newScale = Mathf.Clamp(distance / sizeDevider, 0, sizeClamp);
                    i.localScale = new Vector3(newScale, newScale, newScale);

                }
            }
        }
    }
}

