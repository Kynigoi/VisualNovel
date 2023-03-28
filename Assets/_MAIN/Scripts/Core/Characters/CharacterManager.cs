using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance {get; private set;}
    //private Dictionary<string, Character> characters = new Dictionary<string, Character>();
    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
        else
            DestroyImmediate(gameObject);
    }
}
