using System.Collections;
using UnityEngine;

namespace Assets.Scripts.InterfacePrototyping.Tools
{
    public class SetRenderQueueOfSpriteMaterial : MonoBehaviour
    {
        [SerializeField]
        private int renderQueue = 3000;

        private void OnDrawGizmos()
        {
            GetComponent<Renderer>().sharedMaterial.renderQueue = renderQueue;
        }
    }
}