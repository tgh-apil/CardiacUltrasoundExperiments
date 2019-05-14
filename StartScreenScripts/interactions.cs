using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactions : MonoBehaviour {

    public GameObject mainCam;
    public Transform organModel;
    public Animator organAnim;
    private float mouseX, mouseY;
    public float zoom;
    public float zoomSpeed = 200.0f;
    private float ZOOM_MIN = 0.0f;
    private float ZOOM_MAX = 100.0f;
    private Vector3 mousePos;

    void Start()
    {
        zoom = 0;
    }

    // Update is called once per frame
    void Update()
    {
        zoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        if (zoom > ZOOM_MAX)
            zoom = ZOOM_MAX;

        if (zoom < ZOOM_MIN)
            zoom = ZOOM_MIN;

        mainCam.transform.position = new Vector3(0, 0, zoom);

        if (Input.GetMouseButton(1))
        {
            organAnim.enabled = false;
            float rotX = Input.GetAxis("Mouse X") * 500 * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * 500 * Mathf.Deg2Rad;
            transform.Rotate(Vector3.up, -rotX, Space.World);
            transform.Rotate(Vector3.right, rotY, Space.World);
        }
        else if (Input.GetMouseButton(2))
        {
            organAnim.enabled = false;
            Vector3 delta = Input.mousePosition - mousePos;
            organModel.localPosition = new Vector3 (organModel.position.x + delta.x * 1.5f, organModel.position.y + delta.y * 1.5f, organModel.localPosition.z);
            print(Input.mousePosition);            
        }
        else
        {
            organAnim.enabled = true;
        }
        mousePos = Input.mousePosition;
    }
}
