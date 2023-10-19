using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightController : MonoBehaviour
{
    [SerializeField]
    private Transform joystick;

    void Update()
    {
        transform.position = joystick.position;
        transform.rotation = joystick.rotation;
    }
}
