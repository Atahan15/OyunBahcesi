
using UnityEngine;
public class Camera : MonoBehaviour
{

    public Transform target;
    public float speed;
    public float offset;
    private Vector3 targetVector;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            
            targetVector = new Vector3(Mathf.Clamp(target.position.x,-13.3f,9.52f-offset) //pass player's x if targetposition is between world boundries
                + offset, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetVector, speed);
        
    }
}
