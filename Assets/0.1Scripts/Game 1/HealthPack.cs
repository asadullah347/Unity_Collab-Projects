using UnityEngine;

public class HealthPack : MonoBehaviour
{
    CharacterControll player;

    [SerializeField] float increaseHealth = 10;


    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<CharacterControll>();
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Heal(increaseHealth);
        }
    }

    void Heal(float healthIncrease)
    {
        if (player._Hp < 100)
        {
            player._Hp += healthIncrease;
            Destroy(gameObject);
        }
    }

}
