using UnityEngine;

public class CharacterControll : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] Transform mainCam;
    [SerializeField] GameObject fist;

    [Header("Movement")]
    [SerializeField] float _walkSpeed = 5f;
    [SerializeField] float sprintSpeed = 8f;
    [SerializeField] float trunSpeed = 2f;
    [SerializeField] float jumpF = 2;
    [SerializeField] float gravity = 9.81f;

    [Header("States")]
    public float _Hp;


    private float verticalVelocity;
    private float speed; //to store current speed

    [Header("Input")]
    private float moveInput; // W/S
    private float turnInput; // A/D

    private void Awake()
    {
        fist = GameObject.FindWithTag("Fist");  
        if (fist != null)
        {
            // Optionall fist's collider for better performance
            fist.GetComponent<Collider>().enabled = false;
        }
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        mainCam = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();

        _Hp = 100;


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        InputManagement();
        Movement();

        //Punch
        if(Input.GetKeyDown(KeyCode.E))
        {
            Punch();
        }
    }
    void Movement()
    {
        GroundMovement();
        Trun();
    }

    //1. Get Inputs
    void InputManagement()
    {
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    //claculate dir and assing it.
    void GroundMovement()
    {
        var move = new Vector3(turnInput, 0, moveInput);
        move = mainCam.transform.TransformDirection(move);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = Mathf.Lerp(speed, sprintSpeed, sprintSpeed * Time.deltaTime);
        }
        else
        {
            speed = Mathf.Lerp(speed, _walkSpeed, sprintSpeed * Time.deltaTime);
        }

        move *= speed;

        // Set Y to 0 so the player doesn't fly upwards
        move.y = VerticalForceCalculation();
        controller.Move(move * Time.deltaTime);
    }


    void Trun()
    {
        if(Mathf.Abs(turnInput) > 0 || Mathf.Abs(moveInput) > 0)
        {
            Vector3 currLookDir = controller.velocity.normalized;
            currLookDir.y = 0;

            currLookDir.Normalize();

            Quaternion targetRotation = Quaternion.LookRotation(currLookDir);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * trunSpeed);
        }
    }

    float VerticalForceCalculation()
    {
        if(controller.isGrounded)
        {
            verticalVelocity = -1f;

            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = Mathf.Sqrt(jumpF * gravity * 2);
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        return verticalVelocity;
    }


    void Punch()
    {
        if (fist != null)
        {
            fist.GetComponent<Collider>().enabled = true;
            Invoke("DeactivateFistCollider", 0.3f);  // Disable the fist's collider after 0.2 seconds
        }
    }

    void DeactivateFistCollider()
    {
        if (fist != null)
        {
            fist.GetComponent<Collider>().enabled = false;  // Disable fist collider after the punch
        }
    }

}
