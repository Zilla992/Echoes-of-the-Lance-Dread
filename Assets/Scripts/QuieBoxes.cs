using UnityEngine;

public class QuieBoxes : MonoBehaviour, IItems
{
    void IItems.Collect()
    {
        Destroy(gameObject);
    }
}
