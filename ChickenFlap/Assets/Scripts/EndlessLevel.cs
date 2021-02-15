using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EndlessLevel", menuName = "ScriptableObjects/Endless", order = 3)]
public class EndlessLevel : Level
{
    public override Vector2? GetNextObstacle()
    {
        return obstacles[Random.Range(0, obstacles.Length)];
    }
}
