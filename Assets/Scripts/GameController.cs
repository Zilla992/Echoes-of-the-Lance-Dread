using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Slider healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
