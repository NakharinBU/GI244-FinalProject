using UnityEngine;
using static BulletIdentity;

public class Food : MonoBehaviour
{
    public int attackPoint = 5;

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HealthV1>(out var health) && other.CompareTag("Animal"))
        {
            health.TakeDamage(attackPoint);
        }

        ProjectileObjectPool.GetInstance().Return(gameObject, BulletType.Normal);
    }
}
