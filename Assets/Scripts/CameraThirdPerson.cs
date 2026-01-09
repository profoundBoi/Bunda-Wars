using UnityEngine;

public class CameraThirdPerson : MonoBehaviour
{
    public Transform target;

    public Vector3 offset = new Vector3(0, 3, -6);
    public float followSpeed = 10f;

    void LateUpdate()
    {
        if (!target) return;

        // Rotate offset with player rotation
        Vector3 rotatedOffset = target.rotation * offset;

        Vector3 desiredPos = target.position + rotatedOffset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPos,
            followSpeed * Time.deltaTime
        );

        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
