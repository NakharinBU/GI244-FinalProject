using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    public GameObject optionMenu;
    public void Back()
    {
        optionMenu.SetActive(false);
    }
}
