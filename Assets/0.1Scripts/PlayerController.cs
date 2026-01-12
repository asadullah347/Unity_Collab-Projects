using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Enemy enemy;

    private Rigidbody playerRB;

    public float _speed = 0;
    public float jumpF = 5;
    public float dmg = 10;


    [SerializeField] bool isGrounded;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerRB.freezeRotation = true;
    }

    void FixedUpdate()
    {
        
    }

    private void Update()
    {
        GroundMovement();

        //Jump()
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if(enemy.collided )
        {
            Debug.Log(enemy.name);
        }

        /* //Punch()
        if (Input.GetKeyDown(KeyCode.E) && enemy.collided)
        {
            Punch();
        } */
}

    void GroundMovement()
    {
        Movement();
    }

    void Punch()
    { 
        enemy._enemyHp -= dmg;
    }
    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        _speed = Mathf.Min(5, _speed + 0.1f); // we cap the speed to 5;

        playerRB.MovePosition(transform.position + new Vector3(x, 0, z) * _speed * Time.deltaTime);

    }

    void Jump()
    {
        // playerRB.AddForce(0, jumpF, 0, ForceMode.Impulse);
        playerRB.linearVelocity = new Vector3(0, jumpF, 0);
    }
}
