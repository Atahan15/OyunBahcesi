
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    public static SoundManager Instance;
    AudioSource soundObject;
    [SerializeField] AudioClip hurt;
    [SerializeField] AudioClip playerHurt;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip gameOver;
    [SerializeField] AudioClip shot;
    [SerializeField] AudioClip start;
    

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        soundObject = GetComponent<AudioSource>();
    
    }
    public void Volume(bool isVolumeOpen)
    {
        
        if (!isVolumeOpen) soundObject.volume = 0;
        if (isVolumeOpen) soundObject.volume = 1;
        Debug.Log(soundObject.volume + "  sb deðeri");
    }
    //public void PlaySoundClip(AudioClip clip,Transform transform,float volume)
    //{
    //    AudioSource audioSource = Instance(soundObject,transform.position,Quaternion.identity);
    //    audioSource.clip = clip;
    //    audioSource.volume = volume;
    //    audioSource.Play();
    //    float clipLength=audioSource.clip.length;
    //    Destroy(audioSource,clipLength);
    //}
    private void PitchRandomizer()
    {
        Debug.Log(soundObject.pitch.ToString());
        float randPitch = Random.Range(0.5f, 2f);
        soundObject.pitch = randPitch;
    }
    public void hurtFX()
    {

        PitchRandomizer();
        soundObject.PlayOneShot(hurt);
        
    }
    public void jumpFX()
    {
        soundObject.PlayOneShot(jump);
    }
    public void GameOverFX()
    {
        soundObject.PlayOneShot(gameOver);
    }
    public void PlayerHurtFX()
    {
        PitchRandomizer();
        soundObject.PlayOneShot(playerHurt);
    }
    public void Shot()
    {
        
        soundObject.PlayOneShot(shot);
    }
    public void GameStart()
    {
        soundObject.PlayOneShot(start);
    }


}
