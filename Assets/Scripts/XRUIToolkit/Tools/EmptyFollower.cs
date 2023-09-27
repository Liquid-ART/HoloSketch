using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyFollower : MonoBehaviour
{
    public Transform FollowObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = FollowObject.position;
    }
}
