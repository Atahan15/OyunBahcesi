using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopUpUtilize : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI AchievementName;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Image icon;

    private void Awake()
    {
        
    }

    public void Utilize(Achivement achievement)
    {
        AchievementName.text= achievement.name;
        description.text = achievement.description;
        icon.sprite = achievement.icon;
    }
    
}
