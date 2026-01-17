using Unity.VisualScripting;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    CharacterController Player;
    Transform Camera;

    public float gravity = 9.81f;
    public float speed = 4;

    // we might use this because 
    public Vector3 velocity;
    public Vector3 acceleration;



    void Start()
    {
        Player = GetComponent<CharacterController>();
        Camera = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
        Debug.Log(Camera.position);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        float dt = Time.deltaTime;

        float input_x = Input.GetAxis("Horizontal"); 
        float input_z = Input.GetAxis("Vertical");

        

        Vector3 input = new Vector3(input_x, 0, input_z);

        // making the basis vectors to rotate our 'movment' into camera space(imagine the z and x axis of the camera flat on the ground)
        Vector3 cam_forward = Camera.forward;
        Vector3 cam_right = Camera.right;

        cam_forward.y = 0;
        cam_right.y = 0;

        cam_forward.Normalize();
        cam_right.Normalize();

        Vector3 dir = cam_forward * input.z + cam_right * input.x;

        /* ignore this
        Vector3 targetXZ = dir * 4f; 
        Vector3 currentXZ = new Vector3(velocity.x, 0, velocity.z);

        // dv means the change in velocity, think of this as acceleration.
        Vector3 dv = Vector3.ClampMagnitude(targetXZ - currentXZ, 1.15f);
        velocity += dv;
        */


        if (Player.isGrounded)
        {
            velocity.y = -0.05f; 

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = 5f; // set your jump velocity here
            }
        }

        velocity.y = Mathf.Max(-100, velocity.y - gravity * dt); // gravity

        Vector3 movement = new Vector3(dir.x * speed, velocity.y, dir.z * speed) * dt; // movement we are doing this frame.

        Player.Move(movement);
    }
}
