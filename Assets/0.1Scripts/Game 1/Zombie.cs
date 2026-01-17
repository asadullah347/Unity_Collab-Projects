using UnityEngine;

public class Zombie : MonoBehaviour
{
    CharacterControll player;
    
    private float speed = 4;

    //public Vector3 velocity = new Vector3(0,0,0);

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<CharacterControll>();
    }

    void Update()
    {
        
        Movement();

    }

    void Movement()
    {

        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 15, Color.red);

        // direction to player
        Vector3 dir = new Vector3(player.transform.position.x - transform.position.x , 0 , player.transform.position.z - transform.position.z).normalized;


        transform.rotation = Quaternion.LookRotation(dir);
        transform.position += dir * speed * Time.deltaTime;
    }

    //make functions for behaviour
    void MoveRandom() { 
    

        Vector3 Random_direction = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)).normalized;
        
        transform.rotation = Quaternion.LookRotation(Random_direction);
        transform.position += Random_direction * 4 * Time.deltaTime;


       
        
    }
   
}
