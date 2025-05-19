using UnityEngine;

public class Door : MonoBehaviour
{
    LevelManager levelManager;
    PlayerManager playerManager;

    private void Start()
    { 
        levelManager =FindAnyObjectByType<LevelManager>();
        playerManager = FindAnyObjectByType<PlayerManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            levelManager.NextLevel();
            playerManager.CharacterReset();
        }
    }
}
