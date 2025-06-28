using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage = 3;
    public float maxLifetime = 2f;
    private float lifetime;

    private void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime >= maxLifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BatEnemy bat = collision.GetComponent<BatEnemy>();
        if (bat != null)
        {
            bat.takeDamage(bulletDamage);
            Destroy(gameObject);
            return;
        }

        Destroy(gameObject);
    }
}
