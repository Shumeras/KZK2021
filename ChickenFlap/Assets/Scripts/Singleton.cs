using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
    where T: MonoBehaviour
{
    private static T instance = null;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {

                T[] go = FindObjectsOfType<T>();
                if(go.Length > 1)
                {
                    Debug.LogWarning($"More than one instance found of type {typeof(T)}");
                }
                else if(go.Length < 1)
                {
                    Debug.LogWarning($"No instance found of type {typeof(T)}");
                    return null;
                }
                
                instance = go[0];
            }
            return instance;
        }
    }
}
