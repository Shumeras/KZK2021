using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float   interval;

    private Level currentLevel;

    private float intervalRemaining = 0f;
    private bool isSpawning = true;

    private void Awake() {
        GameController.Instance.gameEndedEvent += OnGameEnded;
    }

    private void Start()
    {
        currentLevel = DataHolder.Instance.levelData[DataHolder.Instance.currentLevel];
        StartCoroutine(SpawnObstacles());
    }

    private void Update() {
    
        
    }

    IEnumerator SpawnObstacles()
    {
        var obstacle = currentLevel.GetNextObstacle();
        if(obstacle == null)
            yield break;

        yield return new WaitForSeconds(obstacle.Value.x);
        while(obstacle != null && isSpawning)
        {
            var obs = Instantiate(prefab, transform);
            obs.transform.Translate(0,obstacle.Value.y,0);

            obstacle = currentLevel.GetNextObstacle();
            
            if(obstacle.HasValue)
                yield return new WaitForSeconds(obstacle.Value.x);
        }
    }

    void OnGameEnded()
    {
        isSpawning = false;
    }

}
