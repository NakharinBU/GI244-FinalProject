using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;

    void Update()
    {
        if (transform.position.z > topBound)
        {
            ProjectileObjectPool.GetInstance().Return(gameObject, BulletType.Normal); // หรือ BulletType.Homing ถ้าต้องแยก
        }
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
