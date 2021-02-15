using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake() 
    {
        if(FindObjectsOfType<DontDestroy>().Length > 1)
        {
            DestroyImmediate(this.gameObject);        
            return;
        }
        
        DontDestroyOnLoad(this.gameObject);    
    }
}
