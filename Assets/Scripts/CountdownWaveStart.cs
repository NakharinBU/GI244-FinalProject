﻿using UnityEngine;
using System.Collections;
using TMPro;

public class CountdownWaveStart : MonoBehaviour
{
    public Wave[] waveConfigurations;
    public WaveController waveController;

    public TextMeshProUGUI countdownText;
    public float countdownDuration = 3f;

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
            countdownText.text = Mathf.Ceil(timer).ToString();
            yield return new WaitForSeconds(1f);
            timer -= 1f;
        }

        countdownText.text = "Start!";
        yield return new WaitForSeconds(0.5f);
        countdownText.gameObject.SetActive(false);

        waveController.StartWave(waveConfigurations[currentWave]);
        waveInProgress = true;
    }
}
