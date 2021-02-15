using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ObstacleDespawner : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log("Collide");
        if(other.gameObject.tag == "Obstacle")
        {
            Destroy(other.transform.gameObject);
        }
    }

}
