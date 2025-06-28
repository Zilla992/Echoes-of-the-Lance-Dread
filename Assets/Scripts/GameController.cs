using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject player;

    public GameObject gameOverScreen;

    public Transform spawnPoint;


    void Start()
    {
        PlayerHealth.OnPlayerDied += GameOverScreen;
        gameOverScreen.SetActive(false);
    }

    public void resetGame()
    {
        gameOverScreen.SetActive(false);
        player.transform.position = spawnPoint.position;

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
    }

    void GameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    void Update()
    {
        
    }
}
