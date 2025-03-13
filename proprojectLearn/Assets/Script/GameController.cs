using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] int totalTime;
    [SerializeField] Text txtTime, txtPoint;
    [SerializeField] GameObject pausePanel;
    int remainTime;
    public static int point = 0;
    float time;
    bool isRunning = true;
    bool isGameOver = false; // Biến kiểm tra trạng thái game
    private int level = 1;
    void Start()
    {
        remainTime = totalTime;
        txtTime.text = $"Time: {remainTime}";
        isRunning = true;
        isGameOver = false;

        pausePanel.SetActive(false);

        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            point = 0;
            PlayerPrefs.SetInt("Point", 0);
            PlayerPrefs.Save();
        }
        else
        {
            point = PlayerPrefs.GetInt("Point", 0);
        }

        level = PlayerPrefs.GetInt("Level", 1);
        if (level == 1)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.Save();
        }

        UpdatePointUI();
    }

    void Update()
    {
        Player player = FindAnyObjectByType<Player>();
        time += Time.deltaTime;
        if (time >= 1)
        {
            time = 0;
            remainTime -= 1;

            if (remainTime < 0) remainTime = 0;
            txtTime.text = $"Time: {remainTime}";

            if (remainTime <= 0 || Player.currentHp <= 0)
            {
                EndGame();
            }
        }


    }


    void EndGame()
    {
        if (isGameOver) return; // Đảm bảo không gọi nhiều lần
        isGameOver = true;      // Đánh dấu game đã kết thúc

        Time.timeScale = 0;
        isRunning = false;

        PlayerPrefs.SetInt("Point", point);
        PlayerPrefs.Save();

        if (Player.currentHp > 0)
        {
            Time.timeScale = 1;
            CheckTime();
            LoadScene();
        }
        else
        {
            SceneManager.LoadScene("Lost");
        }
    }

    public void btnPauseClickHandle()
    {
        if (isRunning)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        isRunning = false;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isRunning = true;
        pausePanel.SetActive(false);
        Debug.Log("click");
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        isGameOver = false;
        Debug.Log("click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Debug.Log("click");
        Application.Quit();
    }

    public void AddPoint(int amount)
    {
        point += amount;
        UpdatePointUI();
        PlayerPrefs.SetInt("Point", point);
        PlayerPrefs.Save();
    }

    void UpdatePointUI()
    {
        txtPoint.text = $"Point: {point}";
    }

    void CheckTime()
    {
        if (remainTime <= 0)
        {
            level += 1;
            PlayerPrefs.SetInt("Level", level);
            PlayerPrefs.Save();
        }
    }
    void LoadScene()
    {
        switch (level)
        {
            case 2:
                SceneManager.LoadScene("IceMap");
                Debug.Log($"level: {level}");
                break;
            case 3:
                SceneManager.LoadScene("FireMap");
                break;
            default:
                SceneManager.LoadScene("Win"); // Nếu vượt quá level 3
                break;
        }
    }
}