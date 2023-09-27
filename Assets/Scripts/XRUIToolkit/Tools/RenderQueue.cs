using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace XRProtoUIToolKit
{
    public class RenderQueue : MonoBehaviour
    {

       [SerializeField]
       public int renderQueue = 3001;

        private void Update()
        {
            TMP_Text text;
            if (TryGetComponent(out text))
            {
                text.fontMaterial.renderQueue = renderQueue;
                return;
            }
        }

        public void UpdateQueue()
       {
            TMP_Text text;
            if (TryGetComponent(out text))
            {
                text.fontMaterial.renderQueue = renderQueue;
                return;
            }

            Image image;
            if (TryGetComponent(out image))
            {
                image.material.renderQueue = renderQueue;
                return;
            }

            Renderer renderer;
            if (TryGetComponent(out renderer))
            {
                renderer.material.renderQueue = renderQueue;
                return;
            }
        }
        
    
    }
}