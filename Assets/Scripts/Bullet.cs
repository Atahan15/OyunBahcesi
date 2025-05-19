using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private Transform muzzleTransform;
    [SerializeField]
    private GameObject bulletprefab;
    public int bulletDamage = 50;
    [SerializeField]
    private float cooldown = 1f;
    private float lasttime = 0;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        muzzleTransform = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && Time.time-lasttime>=cooldown)
        {
            SoundManager.Instance.Shot();
            shot();
            lasttime = Time.time;
        }
    }

    void shot()
    {
        GameObject tempbullet;
        
        tempbullet = Instantiate(bulletprefab,muzzleTransform.position,muzzleTransform.rotation) as GameObject;
        Destroy(tempbullet,1.3f);
        Rigidbody2D temprb=tempbullet.GetComponent<Rigidbody2D>();
        temprb.AddRelativeForce(muzzleTransform.right * 80);


    }
    
}
