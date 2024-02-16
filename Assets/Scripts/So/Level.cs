
using UnityEngine;

[CreateAssetMenu(fileName = "World", menuName = "SO / Level")]

public class Level : ScriptableObject
{
    public int level;
    [Header("Board Dimension")]
    public int width;
    public int height;

    [Header("Starting Tiles")]
    public TileType[] boardLayout;

    [Header("Available Dots")]
    public GameObject[] dots;

    [Header("Score Goals")]
    public int[] scoreGoals;

    [Header("End Game Requirements")]
    public EndGameRequirements endGameRequirements;
    public BlankGoal[] levelGoals;
}
