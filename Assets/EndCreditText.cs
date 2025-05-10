using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class EndCreditText : MonoBehaviour
{
    public RectTransform endGameText;
    public float scrollSpeed = 50f;

    void Start()
    {
        endGameText.DOAnchorPosY(1500, scrollSpeed).SetEase(Ease.Linear).OnComplete(() =>
        {
            Invoke("ReturnToMainmenu", 5f);
        });
    }

    void ReturnToMainmenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
}
