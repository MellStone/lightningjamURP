using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    private Vector3 movementInput;

    CharacterController characterController;
    Rigidbody rb;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        PlayerMovementInput();
        MovePlayer();
        //CharachterControllerMove();
    }

    private void CharachterControllerMove()
    {
        characterController.Move(movementInput * moveSpeed * Time.fixedDeltaTime);

        if (movementInput != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementInput);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        }
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
            // Поворот модели игрока
            Quaternion toRotation = Quaternion.LookRotation(movementInput);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Перемещение игрока
        Vector3 newPosition = rb.position + movementInput * moveSpeed * Time.deltaTime;
        rb.MovePosition(newPosition);
    }
}
