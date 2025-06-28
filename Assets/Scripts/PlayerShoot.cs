using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletSpeed = 20f;

    private PlayerMovement playerMovement;

    private float shootCooldown = 0.3f;
    private float shootTimer = 0f;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (shootTimer > 0f)
            shootTimer -= Time.deltaTime;
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed && shootTimer <= 0f)
        {
            ShootBullet();
            shootTimer = shootCooldown;
        }
    }

    private void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 direction = playerMovement.isFacingRight ? Vector2.right : Vector2.left;
            rb.linearVelocity = direction * bulletSpeed;
        }
        playerMovement.animator.SetTrigger("shoot");
    }

    private void OnDrawGizmosSelected()
    {
        if (shootPoint != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(shootPoint.position, 0.1f);
        }
    }

}
