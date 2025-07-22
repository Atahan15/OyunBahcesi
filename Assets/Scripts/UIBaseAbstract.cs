using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class UIBaseAbstract : MonoBehaviour
{
    //Volume button Field
    [SerializeField] UnityEngine.UI.Image volumeImage;
    [SerializeField] Sprite[] volumeSprite;
    private int volumeIndex = 0;
    bool volumeSwitch = true;



    //Music button Field
    [SerializeField] AudioSource musicSource;
    [SerializeField] UnityEngine.UI.Image musicImage;
    [SerializeField] Sprite[] musicSprite;
    private int musicIndex = 0;
    bool musicSwitch = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {
        Pause();
    }

    public virtual void StartGame()
    {
        this.gameObject.SetActive(false);
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
    public void Pause()
    {
        this.gameObject.SetActive(true);
    }
    public void MusicToggle()
    {
        
        musicIndex = (musicIndex + 1) % musicSprite.Length;
        musicImage.sprite = musicSprite[musicIndex];
        musicSwitch = !musicSwitch;
        musicSource.volume = musicSwitch ? 0.5f : 0f;

    }
    public void VolumeToggle()
    {
        
        volumeIndex = (volumeIndex + 1) % volumeSprite.Length;
        volumeImage.sprite = volumeSprite[volumeIndex];
        volumeSwitch = !volumeSwitch;
        SoundManager.Instance.Volume(volumeSwitch);
    }
}
