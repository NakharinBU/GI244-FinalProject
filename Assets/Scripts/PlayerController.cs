using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float xRange = 10;

    public BulletSwitcher bulletSwitcher;

    private InputAction moveAction;
    private InputAction shootAction;

    private bool hasPowerUp = false;
    private bool hasSlowTime = false;
    private List<MoveForward> moveTargets = new();

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    void Update()
    {
        float horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xRange, xRange), transform.position.y, transform.position.z);

        if (shootAction.triggered)
        {
            GameObject bullet = ProjectileObjectPool.GetInstance().Acquire(bulletSwitcher.currentBulletType);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            hasPowerUp = true;
            StartCoroutine(PowerUpCooldown(5f));
            speed = 30;
        }
        else if (other.CompareTag("SlowTime"))
        {
            Destroy(other.gameObject);
            hasSlowTime = true;
            moveTargets.Clear();
            moveTargets.AddRange(FindObjectsByType<MoveForward>(FindObjectsSortMode.None));
            foreach (var target in moveTargets)
                target.speed = 1f;
            StartCoroutine(SlowTime(5f));
        }
    }

    IEnumerator PowerUpCooldown(float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
        hasPowerUp = false;
        speed = 10;
    }

    IEnumerator SlowTime(float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
        hasSlowTime = false;
        foreach (var target in moveTargets)
        {
            if (target != null) target.speed = 4f;
        }
    }
}
