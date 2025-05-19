using System;
using TMPro;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] MapsScriptable level;
    [SerializeField] TextMeshProUGUI text;
    private string whichLevelAmI;

    public void LevelSelector(int selectedLevel)
    {
        level.currentLevel = selectedLevel;
        whichLevelAmI = Convert.ToString(selectedLevel);

    }
    public void whichLevel()
    {
        
        text.SetText("Seçilen Level="+whichLevelAmI);
    }

}
