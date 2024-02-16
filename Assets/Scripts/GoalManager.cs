using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class BlankGoal
{
    public int numberNeeded;
    public int numberCollected;
    public Sprite goalSprite;
    public string matchValueTag;
}
public class GoalManager : MonoBehaviour
{
    public BlankGoal[] levelGoals;
    public List<GoalPanel> currentGoals = new List<GoalPanel>();
    
    public GameObject goalPrefab;
    public GameObject goalIntroParent;
    public GameObject goalGameParent;

    private Board board;
    private EndGameManager endGameManager;

    
    private void Start()
    {
        endGameManager = FindObjectOfType<EndGameManager>();
        board = FindObjectOfType<Board>();
        GetGoals();
        CreateIntroGoals();
    }

    private void GetGoals()
    {
        if(board != null)
        {
            if(board.world != null)
            {
                if(board.level < board.world.levels.Length)
                {
                    if (board.world.levels[board.level] != null)
                    {
                        levelGoals = board.world.levels[board.level].levelGoals;

                        for(int i = 0; i < levelGoals.Length; i++)
                        {
                            levelGoals[i].numberCollected = 0;

                        }
                    }
                }
            }
        }
    }
    private void CreateIntroGoals()
    {
        for (int i = 0; i < levelGoals.Length; i++)
        {
            // Create Goal Panel at the goalIntroParent position
            GameObject goal = Instantiate(goalPrefab, goalIntroParent.transform.position, Quaternion.identity);
            goal.transform.SetParent(goalIntroParent.transform);

            // Set the Image and Text of the goal
            GoalPanel panel = goal.GetComponent<GoalPanel>();
            panel.thisSprite = levelGoals[i].goalSprite;
            panel.thisString = "0/" + levelGoals[i].numberNeeded;

            // Create Goal Panel at the goalGameParent position
            GameObject gameGoal = Instantiate(goalPrefab, goalGameParent.transform.position, Quaternion.identity);
            gameGoal.transform.SetParent(goalGameParent.transform);

            // Set the Image and Text of the goal for Top UI
            panel = gameGoal.GetComponent<GoalPanel>();
            currentGoals.Add(panel);
            panel.thisSprite = levelGoals[i].goalSprite;
            panel.thisString = "0/" + levelGoals[i].numberNeeded;

        }

    }

    public void UpdateGoals()
    {
        int goalsCompleted = 0;
        for(int i = 0;i < levelGoals.Length;i++)
        {
            currentGoals[i].thisText.text = "" + levelGoals[i].numberCollected + "/" + levelGoals[i].numberNeeded;
            if (levelGoals[i].numberCollected >= levelGoals[i].numberNeeded)
            {
                goalsCompleted++;
                currentGoals[i].thisText.text = "" + levelGoals[i].numberNeeded + "/" + levelGoals[i].numberNeeded;

            }
        }
        
        if(goalsCompleted >= levelGoals.Length)
        {
            if(endGameManager != null)
            {
                endGameManager.WinGame();
            }
            Debug.Log("Win");
        }
    }
    public void CompareGoal(string goalToCompare)
    {
        for(int i = 0; i < levelGoals.Length; i++)
        {
            if(goalToCompare == levelGoals[i].matchValueTag)
            {
                levelGoals[i].numberCollected++;
            }
        }
    }
    
}
    
