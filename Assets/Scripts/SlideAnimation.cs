using System.Collections.Generic;
using UnityEngine;

public class SlideAnimation : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 100f;
    [SerializeField] private float space = 400f;
    [SerializeField] private float waveAmp;
    [SerializeField] private float waveFreq;


    public List<RectTransform> animals;


    private List<float> waveOffsets = new List<float>();

    void Start()
    {
        ShuffleAnimals();

        for (int i = 0; i < animals.Count; i++)
        {
            RectTransform animal = animals[i];


            animal.anchoredPosition = new Vector2(i * space, 0f); //init

            
            waveOffsets.Add(Random.Range(0f, Mathf.PI * 2f));  //it gives different wave patern
        }
    }

    void Update()
    {
        for(int i = 0; i < animals.Count; i++)
        {
            RectTransform animal = animals[i];
            float newX = animal.anchoredPosition.x + scrollSpeed * Time.deltaTime;
            float newY = Mathf.Sin(Time.time * waveFreq + waveOffsets[i]) * waveAmp;
            
            if (newX > space * animals.Count)
            {
                
                animal.anchoredPosition = new Vector2(-100f, newY); //-100 for outside of the screen 
            }
            else animal.anchoredPosition = new Vector2(newX, newY);
        }


    }

    

    void ShuffleAnimals()
    {
        for (int i = 0; i < animals.Count; i++)
        {
            RectTransform temp = animals[i];
            int randomIndex = Random.Range(i, animals.Count);
            animals[i] = animals[randomIndex];
            animals[randomIndex] = temp;
        }
    }
}
