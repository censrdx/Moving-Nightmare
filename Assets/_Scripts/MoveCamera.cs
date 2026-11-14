using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Target to follow.
    [SerializeField] private Transform cameraPosition;

    // Update is called once per frame.
    private void Update()
    {
        // Snap to camera position.
        transform.position = cameraPosition.position;
    }
}