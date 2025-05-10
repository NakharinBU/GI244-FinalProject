using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class WaveSpawnManager : MonoBehaviour
{
    public Wave[] waveConfigurations;
    public WaveController waveController;

    public TextMeshProUGUI countdownText;
    public float countdownDuration = 3f;

    public TextMeshProUGUI waveText;

    private int currentWave = 0;
    private bool waveInProgress = false;

    void Start()
    {
        StartCoroutine(StartNextWaveWithCountdown());
    }

    void Update()
    {
        if (waveInProgress && waveController.IsComplete())
        {
            waveInProgress = false;
            currentWave++;

            if (currentWave >= waveConfigurations.Length)
            {
                Debug.Log("All waves completed!");
                countdownText.text = "Completed!";
                countdownText.gameObject.SetActive(true);
                Invoke("EndCreditScene", 5f);
                
            }
            else
            {
                StartCoroutine(StartNextWaveWithCountdown());
            }
        }
    }

    IEnumerator StartNextWaveWithCountdown()
    {
        float timer = countdownDuration;
        countdownText.gameObject.SetActive(true);

        while (timer > 0)
        {
            countdownText.text = "Next Wave Start in: " + Mathf.Ceil(timer).ToString();
            yield return new WaitForSeconds(1f);
            timer -= 1f;
        }

        countdownText.text = "Start!";
        yield return new WaitForSeconds(0.5f);
        countdownText.gameObject.SetActive(false);

        waveText.text = "Wave: " + (currentWave + 1);

        waveController.StartWave(waveConfigurations[currentWave]);
        waveInProgress = true;
    }

    public void EndCreditScene()
    {
        SceneManager.LoadScene("EndCredits");
    }
}