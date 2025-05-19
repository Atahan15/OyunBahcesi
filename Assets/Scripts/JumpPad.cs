using System.Collections;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    
    [SerializeField] private int jumpForce;
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.rigidbody.linearVelocityY = jumpForce;
            spriteRenderer.sprite = sprites[1];
            StartCoroutine("WaitAndChangeSprite");
        }
        

    }

    private IEnumerator WaitAndChangeSprite()
    {
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.sprite = sprites[0];
    }
}
