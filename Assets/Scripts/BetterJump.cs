using UnityEngine;

public class BetterJump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float shortJumpMultiplier;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        }
        else if (rb.linearVelocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * shortJumpMultiplier * Time.deltaTime;
        }

    }
}
