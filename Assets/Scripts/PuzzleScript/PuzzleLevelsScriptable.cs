using UnityEngine;

[CreateAssetMenu(fileName = "PuzzleLevels", menuName = "ScriptableObjects/PuzzleLevel")]
public class PuzzleLevelsScriptable : ScriptableObject
{
    public Level[] PuzzleLevels;
    public int currentPuzzleLevel;
}
