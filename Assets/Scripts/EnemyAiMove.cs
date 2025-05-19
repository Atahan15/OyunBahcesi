
using UnityEngine;

public class EnemyAiMove : MonoBehaviour
{
    private Collider2D Collider2D;
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] ContactFilter2D contactFilter;
    private RaycastHit2D hit;
    [SerializeField] float originoffsetx= 0.762f;
    [SerializeField] float originoffsety= 0.771f;
    private EnemyManager enemyManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collider2D=GetComponentInChildren<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        enemyManager = GetComponent<EnemyManager>(); 
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(enemyManager.isdead) return;
        rb.linearVelocityX = speed;



        
        Vector2 rayOrigin2 = transform.position;
        rayOrigin2.y -= originoffsety;
        rayOrigin2.x += originoffsetx;
        Debug.DrawRay(rayOrigin2, Vector2.down * 0.3f, Color.black);
        RayCastDetector();

    }
    void Update()
    {
        
    }
    private void RayCastDetector()
    {
        Vector2 rayOrigin= transform.position;
        rayOrigin.y -= originoffsety;
        rayOrigin.x += originoffsetx;

        hit = Physics2D.Raycast(rayOrigin, Vector2.down,0.1f);

        if (!hit)
        {

            this.transform.rotation = new Quaternion(0, 180, 0, 0);
            speed *= -1;
            originoffsetx *= -1; 

        }
        
            
            
        
    }
    
}
