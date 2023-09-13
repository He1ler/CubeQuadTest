using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] playerPaths;
    [SerializeField] int[] lvlNumbers;
    [SerializeField] SaveLoadSystem saveLoadSystem;
    [SerializeField] LevelGenerator levelGenerator;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1f;
        Application.targetFrameRate = 60;
        instance = this;
    }
    public void StartLevel()
    {
        levelGenerator.GenerateLevel(lvlNumbers[saveLoadSystem.CurrentData.level % lvlNumbers.Length]);
        Debug.Log(lvlNumbers[saveLoadSystem.CurrentData.level % lvlNumbers.Length]);
        foreach (GameObject playerPath in playerPaths)
        {
            playerPath.SetActive(true);
        }
        player.SetActive(true);
    }
    public void WinGameUI()
    {
        saveLoadSystem.CurrentData.level += 1;
        saveLoadSystem.SaveDataIntoFile();
    }
}