
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenUI : UIBaseAbstract
{
    public void Shuffle()
    {
        PuzzleManager.Instance.Shuffle();
    }
}
