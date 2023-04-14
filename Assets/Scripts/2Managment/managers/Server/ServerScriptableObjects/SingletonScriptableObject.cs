using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject 
{
    private static T _instantce = null;
    public static T Instance
    {
        get
        {
            if(_instantce == null)
            {
                T[] results = Resources.FindObjectsOfTypeAll<T>();
                if(results.Length == 0)
                {
                    Debug.LogError("SingletonScriptableObject -> Instance -> results length is 0 for type" + typeof(T).ToString() + ".");
                    return null;
                }
                else if(results.Length > 1)
                {
                    Debug.LogError("SingletonScriptableObject -> Instance -> results length is greather than 1 for type" + typeof(T).ToString() + ".");
                    return null;
                }
                _instantce = results[0];
            }
            return _instantce;
        }
    }
}
