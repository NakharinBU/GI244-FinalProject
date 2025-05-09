using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public void ShowUI()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Mainmenu()
    {
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("Mainmenu");
        Time.timeScale = 1;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
