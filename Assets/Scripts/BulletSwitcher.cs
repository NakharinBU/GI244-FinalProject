using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BulletSwitcher : MonoBehaviour
{
    public BulletType currentBulletType = BulletType.Normal;

    public Image nmBullet;
    public Image hmBullet;

    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            currentBulletType = BulletType.Normal;
            SetBulletUIAlpha(nmBullet, 1f);
            SetBulletUIAlpha(hmBullet, 0.4f);

        }
        else if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            currentBulletType = BulletType.Homing;
            SetBulletUIAlpha(hmBullet, 1f);
            SetBulletUIAlpha(nmBullet, 0.4f);

        }
    }

    private void SetBulletUIAlpha(Image img, float alpha)
    {
        Color c = img.color;
        c.a = alpha;
        img.color = c;
    }
}
