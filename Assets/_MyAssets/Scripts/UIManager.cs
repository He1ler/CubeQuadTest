using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("UI")]
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject startImage;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject pauseBtn;
    [Header("Text")]
    [SerializeField] TextMeshProUGUI lvlText;
    bool isStart = true;
    bool isEnd = false;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        lvlText.text = "lvl " + (SaveLoadSystem.instance.CurrentData.level + 1).ToString();
    }
    private void Update()
    {
        StartingFunc();
    }
    void StartingFunc()
    {
        if (Input.GetMouseButtonDown(0) && isStart)
        {
            isStart = false;
            startImage.SetActive(false);
            GameManager.instance.StartLevel();
        }
    }
    public void WinGame()
    {
        if (isEnd)
        {
            return;
        }
        ShowWinGameUI();
        isEnd = true;
    }
    public void LoseGame()
    {
        if (isEnd)
        {
            return;
        }
        ShowLoseGameUI();
        isEnd = true;
    }
    public void PauseGame()
    {
        pausePanel.SetActive(true);
        pauseBtn.SetActive(false);
        Time.timeScale = 0;
    }
    public void UnPauseGame()
    {
        pausePanel.SetActive(false);
        pauseBtn.SetActive(true);
        Time.timeScale = 1;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void ShowWinGameUI()
    {
        winPanel.SetActive(true);
        pauseBtn.SetActive(false);
    }
    public void ShowLoseGameUI()
    {
        losePanel.SetActive(true);
        pauseBtn.SetActive(false);
    }
    public void LoseGameUI()
    {
        RestartGame();
    }
    public void WinGameUI()
    {
        GameManager.instance.WinGameUI();
        RestartGame();
    }
}