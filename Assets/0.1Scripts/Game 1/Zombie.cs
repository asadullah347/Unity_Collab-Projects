using UnityEngine;

public class Zombie : MonoBehaviour
{
    CharacterControll player;
    Rigidbody zombieRB;
    private float speed = 6;

    //public Vector3 velocity = new Vector3(0,0,0);

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


        zombieRB.MovePosition(transform.position + dir * speed * Time.deltaTime);
    }

   
}
