using System.Collections.Generic;
using UnityEngine;

public class ProjectileObjectPool : MonoBehaviour
{
    public GameObject projectilePrefabNormal;
    public GameObject projectilePrefabHoming;
    public int poolSize = 10;

    private List<GameObject> normalPool = new();
    private List<GameObject> homingPool = new();

    private static ProjectileObjectPool instance;

    void Awake()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
    }

    public static ProjectileObjectPool GetInstance() => instance;

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            AddToPool(BulletType.Normal);
            AddToPool(BulletType.Homing);
        }
    }

    void AddToPool(BulletType type)
    {
        GameObject go = Instantiate(type == BulletType.Normal ? projectilePrefabNormal : projectilePrefabHoming);
        go.SetActive(false);
        if (type == BulletType.Normal) normalPool.Add(go);
        else homingPool.Add(go);
    }

    public GameObject Acquire(BulletType type)
    {
        List<GameObject> pool = type == BulletType.Normal ? normalPool : homingPool;
        if (pool.Count == 0) AddToPool(type);

        GameObject obj = pool[0];
        pool.RemoveAt(0);
        obj.SetActive(true);
        return obj;
    }

    public void Return(GameObject obj, BulletType type)
    {
        obj.SetActive(false);
        if (type == BulletType.Normal) normalPool.Add(obj);
        else homingPool.Add(obj);
    }
}
