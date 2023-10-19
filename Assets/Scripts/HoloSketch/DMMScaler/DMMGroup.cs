using UnityEngine;
using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;

namespace HoloSketch
{

    [ExecuteInEditMode]
    public class DMMGroup : MonoBehaviour
    {
        [SerializeField]
        private float scaleFactor = 1f;
        [SerializeField]
        public Transform expectedViewPoint;
        public bool IsActive = true, UpdateInGame = false;
        public Vector2 ScaleClamp = new Vector2(0.5f, 3f);

        void Start()
        {
            Init();
        }

        private void Init()
        {
            if (expectedViewPoint == null)
                expectedViewPoint = FindObjectOfType<ExpectedViewPoint>().transform;
        }

        private void Update()
        {
            transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        }

    }
}
