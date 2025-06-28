using UnityEngine;

public class QuieBoxes : MonoBehaviour, IItems
{
    private SpriteRenderer spriteRenderer;
    public float fadeDuration = 1f;
    private bool isCollected = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void IItems.Collect()
    {
        if (!isCollected)
        {
            isCollected = true;
            StartCoroutine(FadeToGray());
        }
    }

    System.Collections.IEnumerator FadeToGray()
    {
        float elapsed = 0f;
        Color startColor = spriteRenderer.color;
        Color targetColor = Color.gray;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            spriteRenderer.color = Color.Lerp(startColor, targetColor, elapsed / fadeDuration);
            yield return null;
        }
    }
}
