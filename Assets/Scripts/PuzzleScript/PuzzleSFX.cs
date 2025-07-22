using System.Collections;
using UnityEngine;

public class PuzzleSFX : MonoBehaviour
{
    [SerializeField] AudioClip moveClip;
    [SerializeField] AudioClip winFX;
    [SerializeField] AudioClip correctClip;
    private AudioSource soundObject;

    private void Awake()
    {
        soundObject = GetComponent<AudioSource>();
        
    }

    private void Start()
    {
        StartCoroutine(SoundOnOffDelayed());
    }

    public IEnumerator SoundOnOffDelayed()
    {
        soundObject.volume = 0;
        yield return new WaitForSeconds(1f);
        soundObject.volume = 2f;
    }
    


    private void PitchRandomizer()
    {
        float randPitch = Random.Range(0.8f, 1.5f);
        soundObject.pitch = randPitch;
    }
    
    public void PieceMoveSFX()
    {
        
        PitchRandomizer();
        soundObject.PlayOneShot(moveClip);
    }
    public void CorrectPlaceSFX()
    {
        soundObject.PlayOneShot(correctClip);
    }
    public void WinSFX()
    {
        soundObject.PlayOneShot(winFX);
    }
}
