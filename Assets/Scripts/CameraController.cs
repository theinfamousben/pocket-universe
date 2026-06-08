using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject cameraObject;

    private Camera cam;
    private bool dragging;
    private Vector3 lastCameraPos;

    [SerializeField] private float epsilon;
    [SerializeField] float scrollSpeed;
    [SerializeField] private float minZoom;
    [SerializeField] private float maxZoom;
    
    void Start()
    {
        dragging = false;
        
        cam = cameraObject.GetComponent<Camera>();
        if (!cam)
        {
            Logger.AddLog("CameraController.Start: Camera not found", 3);
        }
    }

    void Update()
    {
        GetMouseInput();
    }

    void GetMouseInput()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            Vector2 pos = Mouse.current.position.ReadValue();
            
            if (!dragging)
            {
                dragging = true;
                lastCameraPos = cam.ScreenToWorldPoint(pos);
            }
            else
            {
                Vector3 delta = cam.ScreenToWorldPoint(pos) - lastCameraPos;
                if (delta.magnitude < epsilon) return;
                cam.transform.position -= delta;
                lastCameraPos = cam.ScreenToWorldPoint(pos);
            }
        }
        else
        {
            dragging = false;
        } 
        
        if (Mouse.current.scroll.ReadValue().y != 0)
        {
            float scrollAmount = Mouse.current.scroll.ReadValue().y;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - (scrollAmount * scrollSpeed), minZoom, maxZoom);
        }
    }
}