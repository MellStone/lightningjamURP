using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float cameraSpeed;
    

    private Vector3 offset;
    private Vector3 velocity;

    private void Start()
    {
        offset = transform.position;
        HideCursor();
    }
    private void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, cameraSpeed);

        Quaternion desiredRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * cameraSpeed);
    }


    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
