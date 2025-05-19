using System.Collections;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] Vector2 destinationOne, destinationTwo, destinationThree;
    [SerializeField] int speed;
    [SerializeField] Sprite[] sprites;
    [SerializeField] Transform platformTransform;
    private Vector2 currentPosition;
    private SpriteRenderer spriteRenderer;
    private int currentIndex=0;
    private bool isEntered;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentPosition = platformTransform.position;
    }
    private void Update()
    {
        if (isEntered)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                UseLevarage();
                
                Debug.Log(currentIndex);
            }
        }
    }
    private void ChangeSprite()
    {

        spriteRenderer.sprite = sprites[currentIndex];
    }
    private void UseLevarage()
    {
        currentIndex = (currentIndex + 1) % sprites.Length;
        ChangeSprite();
        MovePlatform();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isEntered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isEntered = false;
        }
    }
    private void MovePlatform()
    {
        Vector2 target = destinationThree;
            switch (currentIndex)
            {
                case 0:
                target = destinationOne;
                    break;
                case 1:
                target = destinationTwo;
                break;
                case 2:
                target = destinationThree;
                break;
                default:
                    Debug.Log("Hata");
                    break;
            
            }
        StartCoroutine(MoveSlowly(target));
        
    }
    
    private IEnumerator MoveSlowly(Vector2 destination)
    {
        float t = 0;
        t += Time.deltaTime * speed;
        while (t<1f) //(Vector2)platformTransform.position!=destination
        {
            t += Time.deltaTime * speed;
            platformTransform.position = Vector2.Lerp(currentPosition, destination, t);
            yield return null;
            
        }
        
        currentPosition = destination;

    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    //private void MoveSlowly(Vector2 destination)
    //{
    //    platformTransform.position = Vector3.Lerp(currentPosition, destination, Time.deltaTime*speed);
    //    currentPosition= destination;
    //}
}
