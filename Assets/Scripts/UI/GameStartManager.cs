using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameStartManager : MonoBehaviour
{
    public  GameObject startPanel;
    public  GameObject levelPanel;

    
    private void Start()
    {
        startPanel.SetActive(true);
        levelPanel.SetActive(false);
    }

    public void PlayButton()
    {
        startPanel.SetActive(false);
        levelPanel.SetActive(true);
    }

    public void Home()
    {
        startPanel.SetActive(true);
        levelPanel.SetActive(false);
    }
}
