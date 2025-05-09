using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Toggle muteToggle;

    private float previousVolume = 0.5f;
    private bool isMuted = false;

    void Start()
    {
        isMuted = PlayerPrefs.GetInt("muted", 0) == 1;

        if (isMuted)
        {
            Mute();
            muteToggle.isOn = false;
        }
        else
        {
            Unmute();
            muteToggle.isOn = true;
        }

        muteToggle.onValueChanged.AddListener(delegate { ToggleMute(muteToggle.isOn); });
    }

    public void ToggleMute(bool isOn)
    {
        if (isOn)
        {
            Unmute();
        }
        else
        {
            Mute();
        }
    }

    void Mute()
    {
        audioMixer.GetFloat("MasterVolume", out float currentVolDB);
        previousVolume = Mathf.Pow(10f, currentVolDB / 20f);
        audioMixer.SetFloat("MasterVolume", -80f);
        isMuted = true;
        PlayerPrefs.SetInt("muted", 1);
    }

    void Unmute()
    {
        SetVolume(previousVolume);
        isMuted = false;
        PlayerPrefs.SetInt("muted", 0);
    }

    void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }
}
