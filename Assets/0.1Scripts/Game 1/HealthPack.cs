using UnityEngine;

public class HealthPack : MonoBehaviour
{
    CharacterControll player;

    private float increaseHealth = 10;


    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<CharacterControll>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (player._Hp < 100)
        {
            player._Hp += increaseHealth;
        }
        
    }

}
