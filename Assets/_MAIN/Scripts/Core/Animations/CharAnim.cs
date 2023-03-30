using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnim : MonoBehaviour
{
    private Animator charAnim;

    void Start() 
    {
       charAnim = GetComponent<Animator>(); 
    }

    void Update() 
    {
        CharacterMotion();
    }

    void CharacterMotion()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            charAnim.SetTrigger("SmileTrigger");
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {

            charAnim.SetTrigger("RandomPoseTrigger");
            
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            charAnim.SetTrigger("SideEyeTrigger");
            
        }
    }
}
