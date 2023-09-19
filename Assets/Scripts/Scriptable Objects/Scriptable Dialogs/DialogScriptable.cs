using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog", menuName = "My Scriptables/New Dialog")]
public class DialogScriptable : ScriptableObject
{
    [Header("[Values]")]
    public string characterName;
    public string dialogText;
    public Sprite characterPortrait;

}
