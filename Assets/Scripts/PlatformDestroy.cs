
using UnityEngine;

public class PlatformDestroy : MonoBehaviour
{
    [SerializeField] private float waitSeconds;
    SpriteRenderer[] spriteRenderers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        Debug.Log("bulunan sprite renderer=" + spriteRenderers.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="Player")
        {

            foreach (SpriteRenderer item in spriteRenderers)
            {
                item.color = new Color(0.7f, 0.216f, 0.230f, 0.6f);
                
            }
            Destroy(this.gameObject, waitSeconds);
        }
    }
}
