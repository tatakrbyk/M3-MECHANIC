using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadePanelController : MonoBehaviour
{
    
    public Animator panelAnim;
    public Animator gameInfoAnim;
   
    public void OkeyButton()
    {
        if (panelAnim != null && gameInfoAnim != null) 
        {
            panelAnim.SetBool("Out", true);
            gameInfoAnim.SetBool("Out", true);
            StartCoroutine(GameStartCo());
        }
    }

    public void GameOver()
    {
        panelAnim.SetBool("Out", false);
        panelAnim.SetBool("Game Over", true);

    }

    private IEnumerator GameStartCo()
    {
        yield return new WaitForSeconds(1f);
        Board board = FindObjectOfType<Board>();

        board.currentState = GameState.move;
    }
}
