using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10f;
    public float momentumDampening = 5f;

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

        CamAnim.SetBool("isWalking", isWalking);
    }

    void GetInput()
    {
        // if we're holding down WASD, then give us 1, 0, -1
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            inputVector.Normalize();
            inputVector = transform.TransformDirection(inputVector);

            isWalking = true;
        }
        // if we're not then lerp the last inputVector down to zero
        else
        {
            inputVector = Vector3.Lerp(inputVector, Vector3.zero, momentumDampening * Time.deltaTime);

            isWalking = false;
        }

        movementVector = (inputVector * playerSpeed) + (Vector3.up * playerGravity);
    }

    void MovePlayer()
    {
        characterController.Move(movementVector * Time.deltaTime);
    }
}