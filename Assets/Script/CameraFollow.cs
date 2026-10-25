using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float cameraSmoothSpeed = 0.125f;
    public float yFixed = 0f;
    public float zFixed = -10f;

    public float minX = -0.17f;     // Minimum X position for the camera
    public float maxX = 16.03f;     // Maximum X position for the camera

    void LateUpdate()
    {
        if (player == null) return;

        // Clamp player's X position between minX and maxX
        float clampedX = Mathf.Clamp(player.position.x, minX, maxX);

        Vector3 desiredPosition = new Vector3(clampedX, yFixed, zFixed);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, cameraSmoothSpeed);

        transform.position = smoothedPosition;
    }
}