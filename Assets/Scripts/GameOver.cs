using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // This is a public refrence to the GameManager component called "GameManager.Restart".
    public void Retry()
    {
        // Find object from game manager in order to restart the game.
        FindObjectOfType<GameManager>().Restart();
    }


    // This is a public refrence to the GameManager component called "GameManager.LoadMenu".
    public void LoadMenu()
    {
        // Find object from game manager in order to load the menu.
        FindObjectOfType<GameManager>().LoadMenu();
    }

    void Update()
    {
        //  Get r key from keyboard.
        if (Input.GetKey("r"))

        {
            FindObjectOfType<GameManager>().Restart();    //  Delete all saved data and start from the begining.
        }
    }
}
