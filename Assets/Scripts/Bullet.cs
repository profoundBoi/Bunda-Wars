using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 40f;
    public float lifeTime = 3f;
    public int damage = 25;

    [HideInInspector] public string ownerTag;

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
        if (other.CompareTag(ownerTag)) return;

        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(damage, ownerTag);
        }

        Destroy(gameObject);
    }
}
