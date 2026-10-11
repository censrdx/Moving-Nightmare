using UnityEngine;

public class DeletePlayerPrefs : MonoBehaviour
{
    // Update is called once per frame
    public void Update()
    {
        //  Get M key from keyboard.
        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayerPrefs.DeleteAll();    //  Delete all saved data.
        }
    }
}
