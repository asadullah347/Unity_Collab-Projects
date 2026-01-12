using Assets._0._1Scripts;
using UnityEngine;

public class Sphere : MonoBehaviour
{
   
    void Start()
    {
        Debug.Log("Minigame started...!!");
    }

    void Update()
    {
        
    }

    void endGame()
    {
        GameManager.Instance.ReturnToLobby();
    }
}