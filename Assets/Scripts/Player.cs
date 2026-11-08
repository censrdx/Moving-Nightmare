using UnityEngine;

public class Player : MonoBehaviour
{
    // Reference the Generated InputMaster.
    private static InputMaster _controls;
    
    // This is a reference to the rigidbody component called "rb".
    [SerializeField] private Rigidbody rb;
    
    // Adjustable forward and sideways force from the inspector
    [SerializeField] private float forwardForce = 3000f;
    [SerializeField] private float sidewaysForce = 55f;
    
    // initialize variables or states before the application starts || https://docs.unity3d.com/6000.0/Documentation/ScriptReference/MonoBehaviour.Awake.html
    private void Awake()
    {
        _controls = new InputMaster();
    }
    
    // Called when a component of an active GameObject is first enabled.
    private void OnEnable()
    {
        Debug.Log("PrintOnEnable: script was enabled");
        _controls.Enable();
    }
    
    // Called when a component itself is disabled or its parent GameObject is deactivated.
    private void OnDisable()
    {
        Debug.Log("PrintOnDisable: script was disabled");
        _controls.Disable();
    }
    
    // Update called at regular, fixed intervals as part of Unity's physics update loop.
    public void FixedUpdate()
    {
        // Add automatic forward force to the player.
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        
        var input = _controls.Player.Movement.ReadValue<float>();
        
        // Read from InputMaster and add sideways velocity.
        
        if (input != 0f)
        {
            Debug.Log("Player is moving");
            rb.AddForce(input * sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // if the player falls off the ground the game ends.
        if (rb.position.y < 0.9f)
        {
            GameManager.Instance.EndGame();
        }

        // Stop movement when game is over and level is completed.
        if (GameManager.GameIsOver || GameManager.LevelIsCompleted)
        {
            this.enabled = false;
        }
    }
}
