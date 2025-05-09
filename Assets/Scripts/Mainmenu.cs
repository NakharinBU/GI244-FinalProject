using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public GameObject optionMenu;

    private void Start()
    {
        optionMenu.SetActive(false);
        
    }

    public void Play() 
    {
        SceneManager.LoadScene("Game");
    }

    // Option
    public void Option()
    {
        optionMenu.SetActive(true);
    }


    public void Exit()
    {
        Application.Quit();
    }

}
