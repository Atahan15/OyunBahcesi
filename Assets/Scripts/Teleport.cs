using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Vector2 destination;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Transform>().position = destination;

        }
    }

}
