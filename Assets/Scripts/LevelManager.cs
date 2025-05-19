using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //singleton?
    [SerializeField] MapsScriptable level;
    private int currentLevel;
    private GameObject loadedMap;
    private GameObject oldMap;

    private void Awake()
    {
        

        currentLevel = level.currentLevel;
    }

    public void StartGame()
    {
        MapSpawner(currentLevel);
    }
    public void NextLevel()
    {
        if (currentLevel + 1 < level.maps.Length)
        {
            DestroyMap();
            MapSpawner(currentLevel + 1);
            level.currentLevel = currentLevel;
        }
        else Debug.Log("level kalmadý");
    }
    
    public void ResetMap()
    {
        oldMap= loadedMap;
        DestroyMap();
        MapSpawner(level.currentLevel);
        
    }
    private void MapSpawner(int index)
    {
        loadedMap = Instantiate(level.maps[index].preFab) as GameObject;
        currentLevel= index;
        
    }
    private void DestroyMap()
    {
        if (loadedMap != null)
        {
            Destroy(loadedMap);
            
        }
        else Debug.Log("ÖncekiMapYok");
    }

    private void OnApplicationQuit()
    {
        level.currentLevel = currentLevel;
    }

    //level selection



}
