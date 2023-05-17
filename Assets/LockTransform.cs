using UnityEngine;

public class LockTransform : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Awake()
    {
        // Store the initial position and rotation
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        // Reset the position and rotation every frame
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
