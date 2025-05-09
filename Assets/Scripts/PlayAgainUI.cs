using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainUI : MonoBehaviour
{
    public GameObject playAgain;
    public void ShowUI()
    {
        playAgain.SetActive(true);
        Time.timeScale = 0;
    }

    public void Mainmenu()
    {
        playAgain.SetActive(false);
        SceneManager.LoadScene("Mainmenu");
        Time.timeScale = 1;
    }

    public void Restart()
    {
        playAgain.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
