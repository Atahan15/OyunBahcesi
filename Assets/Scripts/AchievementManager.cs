using System;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private AchievementScriptable achievementsScriptable;
    public static AchievementManager Instance;
    [SerializeField] private GameObject popUpUI;
    
    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
       DontDestroyOnLoad(this);
    }

    public void UnlockAchievement(string achievementName)
    {
        
        Achivement achievement=achievementsScriptable.achievements.Find(a => a.name == achievementName);
        if (achievement == null)
        {
            Debug.Log("achievement null");
            return;
        }
        if (PlayerPrefs.HasKey(achievementName))
        {
            Debug.Log("Bu baþarým zaten açýlmýþ");
            return;
        }
        PlayerPrefs.SetInt(achievementName,achievement.id);
        PlayerPrefs.Save();
        Debug.Log("Yeni baþarým açýldý isim:" + achievementName + " id: " + achievement.id);
        OnNewAchievement(achievement);

    }
    
    private void OnNewAchievement(Achivement achievement)
    {
        PopUpInstantiate(achievement);
    }

    private void PopUpInstantiate(Achivement achievement)
    {
        GameObject uý=Instantiate(popUpUI, new Vector3(0,0,0), Quaternion.identity);
        PopUpUtilize popUpUtilize = uý.GetComponent<PopUpUtilize>();
        popUpUtilize.Utilize(achievement);
        Destroy(uý, 5f);
    }

    
    
}
