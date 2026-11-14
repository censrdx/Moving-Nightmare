using UnityEngine;
using UnityEngine.InputSystem;

public class DeletePlayerPrefs : MonoBehaviour
{
    // Reference to Delete Player Prefs.
    [SerializeField] private InputAction deletePlayerPrefsAction;

    // Called when a component of an active GameObject is first enabled.
    private void OnEnable()
    {
        deletePlayerPrefsAction.performed += OnDeletePlayerPrefs;
        deletePlayerPrefsAction.Enable();
    }

    // Called when a component itself is disabled or its parent GameObject is deactivated.
    private void OnDisable()
    {
        deletePlayerPrefsAction.performed -= OnDeletePlayerPrefs;
        deletePlayerPrefsAction.Disable();
    }

    // Called automatically when input action is triggered.
    private void OnDeletePlayerPrefs(InputAction.CallbackContext ctx)
    {
        PlayerPrefs.DeleteAll();
    }
    
    // Delete all saved data.
    public void DeletePlayerPref()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Deleting PlayerPrefs");
    }
}
