using UnityEngine;

public class Player : MonoBehaviour
{
    // Reference the generated InputMaster.
    private InputMaster _movement;
    
    // Reference the player's Rigidbody component.
    [SerializeField] private Rigidbody rb;
    
    // Adjustable physics-based movement settings.
    [Header("Forward Force")]
    [SerializeField] private float forwardForce = 3000f;
    
    [Header("Sideways Force")]
    [SerializeField] private float sidewaysForce = 55f;
    [SerializeField] private float maxSidewaysSpeed = 20f;
    [SerializeField] private float sidewaysDeceleration = 4f;
    
    // Store the horizontal movement input.
    private float _horizontalInput;
    
    // initialize variables or states before the application starts || https://docs.unity3d.com/6000.0/Documentation/ScriptReference/MonoBehaviour.Awake.html
    private void Awake()
    {
        _movement = new InputMaster();
    }
    
    // Called when a component of an active GameObject is first enabled.
    private void OnEnable()
    {
        _movement.Enable();
    }
    
    // Called when a component itself is disabled or its parent GameObject is deactivated.
    private void OnDisable()
    {
        _movement.Disable();
    }

    // Update is called every frame, if the MonoBehaviour is enabled.
    private void Update()
    {
        _horizontalInput = _movement.Player.Movement.ReadValue<float>();
    }
    
    // Update called at regular, fixed intervals as part of Unity's physics update loop.
    private void FixedUpdate()
    {
        // Stop movement when game is over and level is completed.
        if (GameManager.GameIsOver || GameManager.LevelIsCompleted)
        {
            this.enabled = false;
            return;
        }
        
        // End the game if the player falls below the ground.
        if (rb.position.y < 0.9f)
        {
            GameManager.Instance.EndGame();
        }
        
        // Add automatic forward force to the player.
        rb.AddForce(Vector3.forward * (forwardForce * Time.fixedDeltaTime), ForceMode.Force);

        // Apply horizontal acceleration to the player.
        rb.AddForce(Vector3.right * (_horizontalInput * sidewaysForce), ForceMode.Acceleration);
        
        // Clamp horizontal velocity.
        var velocity = rb.linearVelocity;
        velocity.x = Mathf.Clamp(velocity.x, -maxSidewaysSpeed, maxSidewaysSpeed);
        
        // Apply horizontal deceleration when no input is detected.
        if (Mathf.Approximately(_horizontalInput, 0f))
        {
            velocity.x = Mathf.MoveTowards(
                velocity.x,
                0f,
                sidewaysDeceleration * Time.fixedDeltaTime
            );
        }
        
        // Apply the modified velocity to the Rigidbody.
        rb.linearVelocity = velocity;
    }
    
    // Called when a GameObject or component is about to be destroyed.
    private void OnDestroy()
    {
        _movement.Dispose();
    }
}
