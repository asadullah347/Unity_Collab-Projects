using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _enemyHp;
    public bool hit = false;

    public bool collided = false;
    void Start()
    {
        _enemyHp = 100;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            collided = true;
            Debug.Log(name + "collided");

        }
    }
    private void OnTriggerExit(Collider other)
    {
        collided = false;
    }
}
