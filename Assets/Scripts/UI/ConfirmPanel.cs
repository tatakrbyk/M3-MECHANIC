using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfirmPanel : MonoBehaviour
{
    [Header("Level Info")]
    public string levelToLoad;
    public int level;
    private int starsActive;
    private int highScore;

    [Header("UI")]
    public Image[] stars;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI starText;


    private GameData gameData;


    private void OnEnable()
    {
        gameData = GetComponent<GameData>();
        LoadData();
        ActivateStars();
        SetText();
    }

    private void LoadData()
    {
        if(gameData != null)
        {
            starsActive = gameData.saveData.stars[level - 1];
            highScore = gameData.saveData.highScores[level - 1];
        }
    }

    private void SetText()
    {
        highScoreText.text = "" + highScore;
        starText.text = "" + starsActive + "/3";
    }

    private void ActivateStars()
    {
        for(int i = 0; i < starsActive; i++)
        {
            stars[i].enabled = true;
        }
    }
    
    public void Cancel()
    {
        this.gameObject.SetActive(false);
    }

    public void Play()
    {
        GameData.gameData.Save();
        PlayerPrefs.SetInt("Current Level", level - 1);
        SceneManager.LoadScene(levelToLoad);
    }

    public bool Erva(int level)
    {
        if (level > 50)
        {
            return true;
        }
        return false;
    }
}
