using UnityEngine;

public class Zombie : MonoBehaviour
{
    CharacterControll player;
    Rigidbody zombieRB;
    private float speed = 6;

    public Vector3 velocity = new Vector3(0,0,0);

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<CharacterControll>();
        zombieRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 dir = (player.transform.position - transform.position).normalized; // direction to player

        velocity.x = Mathf.Min(speed, velocity.x + 0.1f);
        velocity.z = Mathf.Min(speed, velocity.z + 0.1f);


        zombieRB.MovePosition(transform.position + Vector3.Scale(dir, velocity) * Time.deltaTime);
    }

   
}
