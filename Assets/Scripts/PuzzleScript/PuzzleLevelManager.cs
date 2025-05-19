using UnityEngine;

public class PuzzleLevelManager : MonoBehaviour
{
    public static PuzzleLevelManager Instance;
    [SerializeField] PuzzleLevelsScriptable levels;
    private int currentLevel;
    private GameObject loadedMap;
    private GameObject oldMap;
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    private void Start()
    {
        currentLevel = levels.currentPuzzleLevel;
        StartGame();
    }
    public void StartGame()
    {
        MapSpawner(currentLevel);
    }
    public void NextLevel()
    {
        if (currentLevel + 1 < levels.PuzzleLevels.Length)
        {
            DestroyMap();
            MapSpawner(currentLevel + 1);
            levels.currentPuzzleLevel = currentLevel;
        }
        else Debug.Log("level kalmadý");
    }
    private void DestroyMap()
    {
        if (loadedMap != null)
        {
            Destroy(loadedMap);

        }
        else Debug.Log("ÖncekiMapYok");
    }

    private void MapSpawner(int index)
    {
        loadedMap = Instantiate(levels.PuzzleLevels[index].preFab) as GameObject;
        currentLevel = index;
        PrefabPieceToPuzzleManagerList();


    }
    public void PrefabPieceToPuzzleManagerList()
    {

        PuzzleManager.Instance.allPieces.Clear();
        for (int i = 0; i < levels.PuzzleLevels[currentLevel].preFab.transform.childCount; i++)
        {
            PuzzleManager.Instance.allPieces.Add(levels.PuzzleLevels[currentLevel].preFab.transform.GetChild(i).gameObject);
        }

        PuzzleManager.Instance.Inýt();
       
    }
    private void OnApplicationQuit()
    {
        levels.currentPuzzleLevel = currentLevel;
    }
}
