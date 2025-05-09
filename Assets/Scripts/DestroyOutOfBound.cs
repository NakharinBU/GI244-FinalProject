using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    // [1] declare a private float variable to store the top bound
    private float topBound = 30;
    private float lowerBound = -10;

    // Update is called once per frame
    void Update()
    {
        // [2] if the object goes out of the top bound
        if (transform.position.z > topBound)
        {
            //Destroy(gameObject);
            ProjectileObjectPool.GetInstance().Return(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
