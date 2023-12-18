using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 5f;
    public float zoomSpeed = 5f;
    public float minZoomSize = 2f;
    public float maxZoomSize = 15f;
    public float rotationSpeed = 2f;

    private bool isPanning = false;
    private bool isZooming = false;
    private Vector3 lastMousePosition;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        // Check for middle mouse button input
        if (Input.GetMouseButtonDown(2))
        {
            isPanning = true;
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(2))
        {
            isPanning = false;
        }

        // Check for zoom using scroll wheel
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheelInput != 0f)
        {
            isZooming = true;
            float newSize = Mathf.Clamp(cam.orthographicSize - scrollWheelInput * zoomSpeed, minZoomSize, maxZoomSize);
            cam.orthographicSize = newSize;
        }
        else
        {
            isZooming = false;
        }

        // Perform panning
        if (isPanning)
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            Vector3 pan = new Vector3(-delta.x, -delta.y, 0) * panSpeed * Time.deltaTime;
            cam.transform.Translate(pan, Space.Self);
            lastMousePosition = Input.mousePosition;
        }

        // Rotate the plane around Y-axis when right mouse button is held
        if (Input.GetMouseButton(1))
        {
            float rotationX = Input.GetAxis("Mouse X") * rotationSpeed;
            transform.Rotate(Vector3.up, rotationX, Space.World);
        }
    }
}
