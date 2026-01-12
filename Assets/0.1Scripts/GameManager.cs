using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._0._1Scripts
{
    public class GameManager : MonoBehaviour
    {

       // this is a very simple system where you can load various minigames.
       // you can pick a random minigame or pick your own.

        public static GameManager Instance; // uhh this thing makes this global and stuff..?

        public float lobbyTimer = 10f; // in seconds
        public string[] minigames; // yes you have to manually type all the Scenes into this.

        private float accumulated = 0;

        private string currentMiniGame = null;
        private bool Game_start = false;

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            if (Game_start)
            {
                return;
            }

            accumulated += Time.deltaTime;

            if (accumulated > lobbyTimer)
            {
                SelectMiniGame();
                SceneManager.LoadScene(currentMiniGame); // this loads the next scene and then removes the current scene ( also loads the code and objects in that scene)
                accumulated = 0;
                Game_start = true;

            }
        }

        void SelectMiniGame(string minigame = null)
        {
            // here we do a random selection
            if(minigame == null)
            {
                currentMiniGame = minigames[Random.Range(0, minigames.Length)]; // 0 ~ n-1 알아서 해줌. Exculdes the second parameter.
            }
            else
            {
                currentMiniGame = minigame;
            }
        }

        // use this to end minigames.
        public void ReturnToLobby()
        {
            // reset everything and load the "Lobby" Scene.
            accumulated = 0;
            Game_start = false;
            currentMiniGame = null;
            SceneManager.LoadScene("Lobby");
        }
    }
}

