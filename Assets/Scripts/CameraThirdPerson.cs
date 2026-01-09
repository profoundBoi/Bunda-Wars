using UnityEngine;
using UnityEngine.InputSystem;

public class CameraThirdPerson : MonoBehaviour
{
    public Transform target;

    public Vector3 offset = new Vector3(0, 3, -6);
    public float followSpeed = 10f;

    [Header("Look")]
    public float lookSpeed = 120f;
    public float minPitch = -30f;
    public float maxPitch = 45f;

    private float pitch;
    private Vector2 lookInput;

    void LateUpdate()
    {
        if (!target) return;

        pitch -= lookInput.y * lookSpeed * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        Quaternion rotation =
            Quaternion.Euler(pitch, target.eulerAngles.y, 0f);

        Vector3 desiredPos = target.position + rotation * offset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPos,
            followSpeed * Time.deltaTime
        );

        transform.rotation = rotation;
    }

    // INPUT SYSTEM EVENT
 
}
