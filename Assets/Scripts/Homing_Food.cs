using UnityEngine;

public class Homing_Food : MonoBehaviour
{
    public float speed = 10f;
    public float rotateSpeed = 200f;
    public string enemyTag = "Animal";
    public float detectionRadius = 50f;

    private Transform target;

    void Start()
    {
        FindClosestEnemy();
    }

    void Update()
    {
        if (target == null)
        {
            FindClosestEnemy(); // Find another animal if thier lost
            return;
        }

        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Animal");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance && distanceToEnemy <= detectionRadius)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
    }
}
