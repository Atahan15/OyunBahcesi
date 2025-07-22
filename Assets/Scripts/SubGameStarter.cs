
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SubGameStarter : UIBaseAbstract
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] LevelManager levelManager;

    public override void StartGame()
    {
        playerManager.CharacterReset();
        levelManager.ResetMap();
        SoundManager.Instance.GameStart();
        this.gameObject.SetActive(false);

    }
}

    

 

