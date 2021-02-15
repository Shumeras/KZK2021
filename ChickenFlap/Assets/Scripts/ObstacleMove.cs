using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 1f;

    private bool isMoving = true;

    private void Awake() {
        GameController.Instance.gameEndedEvent += OnGameEnded;
    }

    private void FixedUpdate() 
    {
        if(isMoving)
            transform.Translate(Time.fixedDeltaTime * movementSpeed * -1, 0, 0);
    }

    void OnGameEnded()
    {
        isMoving = false;
    }

    private void OnDestroy() 
    {
        if(GameController.Instance != null)
            GameController.Instance.gameEndedEvent -= OnGameEnded;    
    }

}
