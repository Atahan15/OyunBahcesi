using UnityEngine;

public class Saw : MonoBehaviour
{
    
    [SerializeField] private float originOffsetX;
    [SerializeField] private float originOffsetY;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    private Rigidbody2D rb;
    private Vector2 direction = Vector2.right;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = speed * Time.deltaTime;
        if (this.transform.position.y<-50) Destroy(this.gameObject);

        Vector2 rayOrigin2 = transform.position;
        rayOrigin2.y -= originOffsetY;
        rayOrigin2.x += originOffsetX;
        Debug.DrawRay(rayOrigin2, Vector2.right * 0.5f, Color.black);
        RayCastDetector();
        transform.Rotate(0, 0, rotationSpeed);
    }
    
    private void RayCastDetector()
    {
        Vector2 rayOrigin = transform.position;
        rayOrigin.y -= originOffsetY;
        rayOrigin.x += originOffsetX;
        int layerMask = ~(1 << 8 | 1 << 7);
        RaycastHit2D hit =  Physics2D.Raycast(rayOrigin,Vector2.right,0.5f,layerMask);

        if (hit)
        {
            
            speed *= -1;
            rotationSpeed *= -1;
            originOffsetX *= -1;
            direction *= -1;
        }
        //else  transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, transform.eulerAngles.z + rotationSpeed * Time.deltaTime);

    }
}
