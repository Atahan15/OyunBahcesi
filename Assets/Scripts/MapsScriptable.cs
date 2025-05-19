using UnityEngine;

[CreateAssetMenu(fileName = "Levels", menuName ="ScriptableObjects/level")]
public class MapsScriptable : ScriptableObject
{
    public Map[] maps;
    public int currentLevel;
}
