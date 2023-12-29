using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    private Vector3 movementInput;

    [SerializeField] GameObject rotateModel;
    [SerializeField] Animator controller;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        PlayerMovementInput();
        MovePlayer();
    }
    

    void PlayerMovementInput()
    {
        float horizontalInput, verticalInput;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        movementInput = new Vector3(horizontalInput, 0f, verticalInput);
        movementInput.Normalize();
    }
    void MovePlayer()
    {
        if (movementInput != Vector3.zero)
        {
            controller.SetBool("isRunning", true);
            // Rotating player model
            Quaternion toRotation = Quaternion.LookRotation(movementInput);
            rotateModel.transform.rotation = Quaternion.Slerp(rotateModel.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
            controller.SetBool("isRunning", false);
        // Player movement
        Vector3 newPosition = rb.position + movementInput * moveSpeed * Time.deltaTime;
        rb.MovePosition(newPosition);
    }
}