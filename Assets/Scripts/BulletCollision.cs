using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private int currentindex = 0;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        spriteRenderer.color = new Color(0.9f, 0.216f, 0.216f);
        currentindex = (currentindex + 1) % sprites.Length;
        spriteRenderer.sprite = sprites[currentindex];
    }
}
