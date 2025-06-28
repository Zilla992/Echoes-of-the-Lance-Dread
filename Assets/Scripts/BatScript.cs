using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BatEnemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectionRange = 5f;
    public Transform player;

    public int damage = 4;
    public int maxHealth = 12;
    private int currentHealth;
    private SpriteRenderer spriteRenderer;
    private Color ogcolor;  

    private Vector3 startPosition;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        startPosition = transform.position;

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        ogcolor = spriteRenderer.color;
    }

    void Update()
    {
        animator.SetBool("isFlying", true);
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < detectionRange)
        {
            FollowPlayer();
        }
        else
        {
            ReturnToStart();
        }
    }

    void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    void ReturnToStart()
    {
        transform.position = Vector2.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        StartCoroutine(FlashWhite());
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private IEnumerator FlashWhite()
    {
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = ogcolor;
    }
}
