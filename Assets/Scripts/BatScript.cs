using UnityEngine;

public class BatEnemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectionRange = 5f;
    public Transform player;

    public int damage = 4;

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
        var rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 1f;
    }
}
