using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 20f;
    private CharacterController characterController;

    private Vector3 inputVector;
    private Vector3 movementVector;
    private float playerGravity = -10f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        GetInput();
        MovePlayer();
    }

    void GetInput()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);

        movementVector = (inputVector * playerSpeed) + (Vector3.up * playerGravity);
    }

    void MovePlayer()
    {
        characterController.Move(movementVector * Time.deltaTime);
    }
}
