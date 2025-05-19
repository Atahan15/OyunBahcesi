using UnityEngine;

public class PlatformMove : MonoBehaviour
{

    [SerializeField] float minX = 10f;
    [SerializeField] float maxX = 10f;
    [SerializeField] float speed = 1;
    [SerializeField] float currentX;

    private void Start()
    {
        currentX = transform.position.x;
    }
    // Update is called once per frame
    void Update()
    {
        float x= Mathf.Lerp(currentX-minX, currentX+maxX, Mathf.PingPong(Time.time * speed, 1.0f));
        transform.position=new Vector3(x, transform.position.y,transform.position.z);
    }
}
