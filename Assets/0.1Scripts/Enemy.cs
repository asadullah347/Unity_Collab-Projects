using UnityEngine;

public class Enemy : MonoBehaviour
{
    CharacterControll player;

    public float _enemyHp;
    private float dmg = 10;

    public bool hit = false;
    public bool collided = false;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<CharacterControll>();
        _enemyHp = 100;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fist"))
        {
            collided = true;
            Destroy(gameObject);
        }

        if(other.gameObject.CompareTag("Player"))
        {
            player._Hp -= dmg;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        collided = false;
    }
}
