using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private bool godMod;
    [SerializeField] public float health = 100;
    [SerializeField] SubGameStarter gameStarter;
    private bool isdead = false;


    private void Start()
    {
            rb = GetComponent<Rigidbody2D>();
    }
    public void GotHit(int damage)
    {
        
        if (isdead) return;
        health = health-damage;
        if (health <= 0)
        {
            
            Die();
            return;
        }
        SoundManager.Instance.PlayerHurtFX();
    }
    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        isdead = true;
        SoundManager.Instance.GameOverFX();

        if(!godMod)
        {
            gameStarter.pause();
            gameObject.SetActive(false);
        }
        else
        {
            CharacterReset();
        }

    }
    public void CharacterReset()
    {
        
        isdead =false;
        gameObject.SetActive(true);
        this.transform.position = new Vector3(-23, 2.3f, 0);
        health = 100;
        rb.bodyType = RigidbodyType2D.Dynamic;

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Trap")
        {
            GotHit(100);
            
        }
        else if (other.gameObject.tag == "Enemy")
        {
            GotHit(other.gameObject.GetComponent<EnemyManager>().damage);
        }
    }
   

}

