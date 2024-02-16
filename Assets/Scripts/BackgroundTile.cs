using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundTile : MonoBehaviour
{
    public int hitPoints;
    private SpriteRenderer sprite;
    private GoalManager goalManager;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        goalManager = FindObjectOfType<GoalManager>();

    }

    private void Update()
    {
        if( hitPoints <= 0)
        {
            if (goalManager != null)
            {
                // by tag numberCollected++ 
                goalManager.CompareGoal(this.gameObject.tag);

                // Update Collected Text exm. 3/5 ,if reached goals show Win UI
                goalManager.UpdateGoals();
            }
            Destroy(this.gameObject);
        }
        
    }

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        MakeLighter();
    }

    private void MakeLighter()
    {
        // take the current color 
        Color color = sprite.color;

        // Get the current color's alpha value end cut it in half
        float newAlpha = color.a * .5f;
        sprite.color = new (color.r, color.g, color.b, newAlpha);
    }
}
