
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Transform tr;
    public int enemyHealth = 100;
    public int damage = 30;
    public SpriteRenderer spriteRenderer;
    private Vector2 firstPosition;
    [HideInInspector] public bool isdead = false;
    
    //private bool busy = false;
    //private float lasttime;

    void Start()
    {
        
        tr=GetComponent<Transform>();
        firstPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {

    }
    void GotHit(int damageTaken)
    {
        
        SoundManager.Instance.hurtFX();
        if ( enemyHealth-damageTaken<=0)
        {
            
            Disappear();
            isdead = true;
            return;
        }
        
        enemyHealth = enemyHealth-damageTaken;
        spriteRenderer.color = new Color(0.841f, 0.2f, 0.2f);

        
    }
    public void ResetEnemy()
    {
        Debug.Log("resetenemy");
        Appear();
        enemyHealth = 100;
        spriteRenderer.color = Color.white;
        isdead = false;
        Debug.Log(this.gameObject.name);
        transform.position = firstPosition;

    }

    private void Disappear()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        spriteRenderer.enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        
    }
    private void Appear()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        spriteRenderer.enabled = true;
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag=="Bullet")
        {
            //direct referance ile optimize edilecek
            int bulletdamage = GameObject.Find("Muzzle").GetComponent<Bullet>().bulletDamage;
            GotHit(bulletdamage);
            Destroy(other.gameObject);
            
            
        }
        
    }
    

}