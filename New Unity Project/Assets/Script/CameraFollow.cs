using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Camera stats
    public Transform Player;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    //Transform camera to the players position.
    private void LateUpdate()
    {
        transform.position = Player.position + offset;
    }
}
