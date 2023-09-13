using UnityEngine;
using System.IO;
public class SaveLoadSystem : MonoBehaviour
{
    public static SaveLoadSystem instance;
    public GameData CurrentData;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        if (File.Exists(Application.persistentDataPath + "/CubeQuad.Heller"))
        {
            TransitDataToCurrent();
            return;
        }
        NewData();
        SaveDataIntoFile();
    } 
    public void NewData()
    {
        CurrentData = new GameData();
    }
    public GameData TransitDataToCurrent()
    {
        CurrentData = new GameData(DataTransition.MapNameFromFile());
        return CurrentData;
    }
    public void SaveDataIntoFile()
    {
        DataTransition.MapNameToFile(CurrentData);
    }
}