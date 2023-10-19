
using UnityEngine;
using DG.Tweening;

public class LookAtCamera : MonoBehaviour
{
    public Transform Camera;

    void Update()
    {
        transform.LookAt(Camera);
    }
}
