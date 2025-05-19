using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenUI : MonoBehaviour
{
    [SerializeField] private GameObject achievementPanel;
    public Animator animator;
   
   public void GoToSelectedScene(int selectedIndex)
    { 
        StartCoroutine(LoadLevel(selectedIndex));
    }
    
    private IEnumerator LoadLevel(int selectedIndex)
    {
        StartOutro(animator);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(selectedIndex);

    }
    public void StartOutro(Animator animator)
    {
        animator.SetTrigger("Start");
    }
    public void ActivatePanel()
    {
        achievementPanel.SetActive(true); 
    
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
