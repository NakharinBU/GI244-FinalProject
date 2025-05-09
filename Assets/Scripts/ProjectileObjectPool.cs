using System.Collections.Generic;
using UnityEngine;

public class ProjectileObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject projectliePrefabHoming;
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
        GameObject ph = Instantiate(projectliePrefabHoming);
        p.SetActive(false);
        projectilePool.Add(p);
        ph.SetActive(false);
        projectilePool.Add(ph);
    }

    public GameObject Acquire()
    {   
        if (projectilePool.Count == 0)
        {
            CreateNewProjectile();
        }

        GameObject p = projectilePool[0];
        projectilePool.Remove(p);
        GameObject ph = projectilePool[0];
        projectilePool.Remove(ph);
        //projectilePool.RemoveAt(0);
        p.SetActive(true);
        ph.SetActive(true);
        return p;
    }

    public void Return(GameObject projectile)
    {
        projectilePool.Add(projectile);
        projectile.SetActive(false);
    }
}
