using UnityEngine;
using UnityEngine.EventSystems;

public class GazePointer : MonoBehaviour
{
    [SerializeField]
    private VRInputModule m_InputModule;
    public PointerEventData data;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // UpdateLine();
        m_InputModule.Process();
    }

 

    private RaycastHit CreateRaycast()
    {
        RaycastHit hit;
        Ray ray = new Ray(this.gameObject.transform.position, transform.forward);
        Physics.Raycast(ray, out hit);
        return hit;
    }
}
