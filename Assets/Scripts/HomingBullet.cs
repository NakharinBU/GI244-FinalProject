using UnityEngine;
using static BulletIdentity;

public class HomingBullet : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    public int attackPoint = 10;
    void OnEnable()
    {
        FindNearestEnemy();
    }

    void Update()
    {
        if (target == null)
        {
            ProjectileObjectPool.GetInstance().Return(gameObject, BulletType.Homing);
            return;
        }

        Vector3 dir = (target.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }

    void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Animal");
        float shortestDistance = Mathf.Infinity;
        GameObject nearest = null;

        foreach (var enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < shortestDistance)
            {
                shortestDistance = dist;
                nearest = enemy;
            }
        }

        if (nearest != null)
        {
            target = nearest.transform;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HealthV1>(out var health) && other.CompareTag("Animal"))
        {
            health.TakeDamage(attackPoint);
        }
        ProjectileObjectPool.GetInstance().Return(gameObject, BulletType.Homing);
    }
}
