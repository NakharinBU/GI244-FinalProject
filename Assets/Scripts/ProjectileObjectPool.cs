using System.Collections.Generic;
using UnityEngine;

public class ProjectileObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int initialPoolSize = 10;

    private readonly List<GameObject> projectilePool = new();

    private static ProjectileObjectPool staticInstance;

    private void Awake()
    {
        if (staticInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        staticInstance = this;
    }

    public static ProjectileObjectPool GetInstance() 
    {
        return staticInstance;
    }

    private void Start()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateNewProjectile();
        }
    }

    private void CreateNewProjectile()
    {
        GameObject p = Instantiate(projectilePrefab);
        p.SetActive(false);
        projectilePool.Add(p);
    }

    public GameObject Acquire()
    {
        if (projectilePool.Count == 0)
        {
            CreateNewProjectile();
        }

        GameObject p = projectilePool[0];
        projectilePool.Remove(p);
        //projectilePool.RemoveAt(0);
        p.SetActive(true);
        return p;
    }

    public void Return(GameObject projectile)
    {
        projectilePool.Add(projectile);
        projectile.SetActive(false);
    }
}
