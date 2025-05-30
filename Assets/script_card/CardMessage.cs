using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;


[CreateAssetMenu(fileName = "NewCard",menuName = "Card")]
public class CardMessage : ScriptableObject
{
    
    public string Card_Text;
    public int Card_Cost;
    public int Card_Level;
    public string Card_Name;


    public Sprite Card_Back;
    public Sprite Card_NameBack;
    public Sprite Card_LevelBack;
    public Sprite Card_CostBack;
    public Sprite Card_TextBack;
    public Sprite Card_Art;
    public Sprite Card_Frame;
}
