
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SubGameStarter : MonoBehaviour
{
    [SerializeField] Sprite[] volumeSprite; 
    private int currentindex = 0;
    UnityEngine.UI.Image buttonVolumeImage;

    public GameObject Mainpanel; //anascenegidecekkoduyaz
    [SerializeField] PlayerManager playerManager;
    
    private GameObject[] enemyObjects;
    bool volumeSwitch= true;
    bool musicSwitch = true;

    [SerializeField] LevelManager levelManager;
    [SerializeField] AudioSource musicSource;
    //int currentindex2 = 0;

    private void Awake()
    {
        //buttonVolumeImage = transform.Find("VolumeImage").GetComponent<UnityEngine.UI.Image>();
        buttonVolumeImage=transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetComponent<UnityEngine.UI.Image>();
        //playerManager = FindAnyObjectByType<PlayerManager>();
        enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        
    }
    void Start()
    {
        
        pause();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void pause()
    {
        this.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }
    public void Resume()
    {
        levelManager.ResetMap();
        SoundManager.Instance.GameStart();
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
        playerManager.CharacterReset();
        
        
    }
    public void StartGameMap()
    {
        levelManager.StartGame();
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
    public void VolumeButton()
    {
        currentindex=(currentindex+1)% volumeSprite.Length;
        buttonVolumeImage.sprite = volumeSprite[currentindex];
        volumeSwitch = !volumeSwitch;
        SoundManager.Instance.Volume(volumeSwitch);
        
        


    }
    public void MusicButton()
    {
        musicSwitch = !musicSwitch;
        musicSource.volume = Convert.ToInt32(musicSwitch);
        
    }
    public void LoseScreenResume()
    {
        Debug.Log("losescreenresume");
        playerManager.CharacterReset();
        Resume();
    }

    //Ýf LevelManager respawns the map prefab dont use 
    public void EnemyRespawner()
    {

        foreach (GameObject item in enemyObjects)
        {
            //if (item.GetComponent<EnemyManager>().isdead)  caný az düþmanlar resetlenmez
            item.GetComponent<EnemyManager>().ResetEnemy();

        }
    }
}

