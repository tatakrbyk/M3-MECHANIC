using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToSplash : MonoBehaviour
{
    private GameData gameData;
    private Board board;
    public string sceneToLoad = "Splash";

    private void Start()
    {
        gameData = FindObjectOfType<GameData>();
        board = FindObjectOfType<Board>();
    }
    public void WinOk()
    {
        if (gameData != null)
        {
            gameData.saveData.isActive[board.level + 1] = true;
            gameData.Save();
        }
        SceneManager.LoadScene(sceneToLoad);
        
    }

    public void LoseOK()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
