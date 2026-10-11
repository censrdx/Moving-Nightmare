using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void Retry()
    {
        // Find object from game manager and restart the level.
        GameManager.Instance.Restart();
    }
    
    public void LoadMenu()
    {
        // Find object from game manager and load the menu.
        GameManager.Instance.LoadMenu();
    }
    
    //  Keybind for quick restart.
    private void Update()
    {
        //  Get r key from keyboard.
        if (Input.GetKey("r"))

        {
            GameManager.Instance.Restart();
        }
    }
}
