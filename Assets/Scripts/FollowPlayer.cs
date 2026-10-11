using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //Reference To The Player's Camera Position |"Transform" Link Of The Player To Player's Position, Rotation And Scale.
    public Transform player;
    //Third Person Mode
    public Vector3 offset;

    // Update is called once per frame
    public void Update()
    {
        transform.position = player.position + offset; // set camera to follow the player once per frame.
    }
}
