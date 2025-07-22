using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Achievements", menuName = "ScriptableObjects/achievement")]
public class AchievementScriptable : ScriptableObject
{
    public List<Achivement> achievements;
}
