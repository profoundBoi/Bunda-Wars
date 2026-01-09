using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 40f;
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        // TODO: Damage logic
        Destroy(gameObject);
    }
}
