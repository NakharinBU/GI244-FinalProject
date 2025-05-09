using UnityEngine;

public class Food : MonoBehaviour
{
    public int attackPoint = 5;

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HealthV1>(out var health) && other.gameObject.CompareTag("Animal"))
        {
            health.TakeDamage(attackPoint);
        }
        //Destroy(gameObject);
        ProjectileObjectPool.GetInstance().Return(gameObject);
    }
}
