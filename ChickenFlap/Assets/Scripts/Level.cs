using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 2)]
public class Level : ScriptableObject 
{
    protected int currentObstacle = 0;
    public Vector2[] obstacles;

    public virtual Vector2? GetNextObstacle()
    {
        if(currentObstacle >= obstacles.Length)
        {
            currentObstacle = 0;
            return null;
        }
        
        currentObstacle++;
        return obstacles[currentObstacle-1];
    }
    
}
