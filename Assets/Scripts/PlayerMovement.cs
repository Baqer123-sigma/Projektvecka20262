using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 20f;
    private CharacterController characterController;
    public Animator CamAnim;
    private bool isWalking;

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
        CheckForHeadBob();

        CamAnim.SetBool("isWalking", isWalking);
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

    void CheckForHeadBob()
    {
        if (characterController.velocity.magnitude > 0.1f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }
}