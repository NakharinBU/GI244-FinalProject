using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam05 : MonoBehaviour
{
    public float speed;
    public float xRange = 10;
    public GameObject projectilePrefab;


    // Exam 05 ...
    public int maxBulletCount = 10;
    public float bulletRegenerateCooldown = 1f;
    // ...

    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private int remainingBulletCount;

    private float regenCooldownTimer = 0;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");

        remainingBulletCount = maxBulletCount;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (shootAction.triggered && remainingBulletCount > 0)
        {
            remainingBulletCount--;
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            regenCooldownTimer = bulletRegenerateCooldown;
        }

        if (remainingBulletCount <= 0)
        {
            regenCooldownTimer -= Time.deltaTime;
            if (regenCooldownTimer <= 0)
            {
                remainingBulletCount = maxBulletCount;
            }
        }
    }
}
