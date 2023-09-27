using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace XRProtoUIToolKit
{
    public class RenderQueueGroup : MonoBehaviour
    {
        [SerializeField]
        private int renderQueue = 3000;

        private void Update()
        {
           // UpdateGroup();
        }
        public void UpdateGroup()
        {
           // RenderQueue[] renderQueues = GetComponentsInChildren<RenderQueue>();

            TMP_Text[] texts = GetComponentsInChildren<TMP_Text>();

            if (texts.Length > 0)
            {
                foreach(var i in texts)
                {
                    i.fontMaterial.renderQueue = renderQueue;
                }
            }



            Image[] images = GetComponentsInChildren<Image>();
            if (images.Length > 0)
            {
                foreach (var i in images)
                {
                    i.material.renderQueue = renderQueue;
                }
            }

            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            if (renderers.Length > 0)
            {
                foreach (var i in renderers)
                {
                    i.sharedMaterial.renderQueue = renderQueue;
                }
            }



      /*      foreach (var i in renderQueues)
            {
                i.renderQueue = renderQueue;
                i.UpdateQueue();
            }*/
        }
    }
}

