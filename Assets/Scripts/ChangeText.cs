using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    [SerializeField] private Text[] texts;
    [SerializeField] private List<string> sentences;
    private bool isTriggered;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!isTriggered && other.gameObject.CompareTag("Player") && texts != null)
        {
            int safeIndex = Mathf.Min(texts.Length, sentences.Count);
            for (int i = 0; i < safeIndex; i++)
            {
                texts[i].text = sentences[i];
            }
            isTriggered = true;
        }
    }

}
