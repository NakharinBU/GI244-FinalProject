using UnityEngine;

public class GameState : MonoBehaviour
{
    private int hitCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            hitCount++;
            if (hitCount >= 5)
            {
                Debug.Log("Game Over!");
                Time.timeScale = 0;
            }
        }
    }
}
