using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    private void LateUpdate()
    {
        transform.position = Player.position + offset;
    }
}
