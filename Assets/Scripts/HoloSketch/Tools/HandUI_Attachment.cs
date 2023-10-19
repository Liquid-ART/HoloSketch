
using UnityEngine;
using DG.Tweening;


public class HandUI_Attachment : MonoBehaviour
{
    [SerializeField]
    private Transform controllerAttachmentPoint;


    private void Start()
    {
        transform.position = controllerAttachmentPoint.position;
        transform.rotation = controllerAttachmentPoint.rotation;
    }




    void Update()
    {

        transform.DOMove(controllerAttachmentPoint.position, 0.7f);
      // transform.position = controllerAttachmentPoint.position;
        Vector3 targetRot = controllerAttachmentPoint.rotation.eulerAngles;
        Vector3 rotateTo = new Vector3(0, targetRot.y, 0);
       transform.DORotate(rotateTo, 0.7f); 


    }



}
