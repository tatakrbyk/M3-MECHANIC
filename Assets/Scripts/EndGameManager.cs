using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameType
{
    Moves,
    Time
}

[System.Serializable]
public class EndGameRequirements
{
    public GameType gameType;
    public int counterValue;
}
public class EndGameManager : MonoBehaviour
{
    private Board board;
    public GameObject movesLabel;
    public GameObject timeLabel;
    public GameObject winPanel;
    public GameObject tryAgainPanel;
    public TextMeshProUGUI counterText;

    public int currentCounterValue;

    public EndGameRequirements requirements;
    private float timerSeconds;

  
    private void Start()
    {
        board = FindObjectOfType<Board>();
        SetGameType();
        CreateGame();
    }

    private void SetGameType()
    {
        if (board.world != null) 
        { 
            if (board.level < board.world.levels.Length)
            {
                if (board.world.levels[board.level] != null)
                {
                    requirements = board.world.levels[board.level].endGameRequirements;
                }
            }
        }
    }

    private void CreateGame()
    {
        currentCounterValue = requirements.counterValue;
        
        if(requirements.gameType == GameType.Moves)
        {
            movesLabel.SetActive(true);
            timeLabel.SetActive(false);
        }
        else
        {
            timerSeconds = 1;
            movesLabel.SetActive(false);
            timeLabel.SetActive(true);
        }
        counterText.text = "" + currentCounterValue;
    }

    public void DecreaseCounterValue()
    {
        if (board.currentState != GameState.pause)
        {
            currentCounterValue--;
            counterText.text = "" + currentCounterValue;
            
            if(currentCounterValue <= 0)
            {
                LoseGame();
            }
        }
    }

    public void WinGame()
    {
        winPanel.SetActive(true );
        board.currentState = GameState.win;
        currentCounterValue = 0;
        counterText.text = "" + currentCounterValue;
        
        FadePanelController fade =  FindObjectOfType<FadePanelController>();
        fade.GameOver();
    }

    public void LoseGame()
    {
        tryAgainPanel.SetActive(true);
        board.currentState = GameState.lose;

        currentCounterValue = 0;
        counterText.text = "" + currentCounterValue;
        FadePanelController fade =  FindObjectOfType<FadePanelController>();
        fade.GameOver();
    }

    private void Update()
    {
        if(requirements.gameType == GameType.Time && currentCounterValue > 0)
        {
            timerSeconds -= Time.deltaTime;
            if(timerSeconds <= 0)
            {
                DecreaseCounterValue();
                timerSeconds = 1;
            }
        }
    }
}
