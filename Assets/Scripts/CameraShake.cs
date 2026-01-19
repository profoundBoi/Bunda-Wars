using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float intensity = 0.2f;
    public float duration = 0.15f;

    Vector3 startPos;

    void Awake()
    {
        startPos = transform.localPosition;
    }

    public void Shake()
    {
        StopAllCoroutines();
        StartCoroutine(DoShake());
    }

    System.Collections.IEnumerator DoShake()
    {
        float t = 0f;
        while (t < duration)
        {
            transform.localPosition = startPos + Random.insideUnitSphere * intensity;
            t += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = startPos;
    }
}
