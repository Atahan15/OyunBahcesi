using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenUI : MonoBehaviour
{
    [SerializeField] GameObject GameManager;
    private PuzzleManager puzzleManager;
    [SerializeField] Sprite[] volumeSprite;
   
    private int currentindex = 0;
    UnityEngine.UI.Image buttonVolumeImage;

    bool volumeSwitch = true;
    bool musicSwitch = true;

    private void Awake()
    {
        
    }
    private void Start()
    {
        //buttonVolumeImage = transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetComponent<UnityEngine.UI.Image>();
    }

    public void pause()
    {
        
        this.gameObject.SetActive(true);


    }

    public void resume()
    {
       
        this.gameObject.SetActive(false);

        
    }

    public void VolumeButton()
    {
        currentindex = (currentindex + 1) % volumeSprite.Length;
        buttonVolumeImage.sprite = volumeSprite[currentindex];
        volumeSwitch = !volumeSwitch;
        //SoundManager.Instance.Volume(volumeSwitch);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void Shuffle()
    {
        PuzzleManager.Instance.Shuffle();
        
    }
}
