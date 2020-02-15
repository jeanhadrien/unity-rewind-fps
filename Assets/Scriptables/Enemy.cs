using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy", order = 51)]
public class Enemy : ScriptableObject
{
    public string[] names = {"Michel","Jean","Pierre","xXEn3myXx"};
    public string[] onDeath = {"R.I.P",
            "Guess I'll die",
            "Cya",
            "*dies*",
            "..."
        };
    public string[] onDialogue = {
            "Hello, how's it going?",
            "What do you think of Scriptable Objects?",
            "Please don't kill me >.>",
            ":D",
            "Can't wait for 2020.1 !",
            "<insert dialogue here>",
            ":P",
            "^^",
            ":)"
        };
    
}
