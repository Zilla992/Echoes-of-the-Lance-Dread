using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour, IItems
{
    void IItems.Collect()
    {
        Destroy(gameObject);
    }
}
