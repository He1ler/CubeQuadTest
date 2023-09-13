// Data for game variables
[System.Serializable]
public class GameData
{
    public int level;
    public GameData()// saving starting variables for new game
    {
        level = 0;
    }
    public GameData(GameData hs)// saving variables for loading level
    {
        level = hs.level;
    }
}