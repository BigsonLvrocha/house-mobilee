using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;        
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName="Furniture",menuName="Scriptable/Furnitures",order=1)]
public class FurnitureScriptable : ScriptableObject {
    public int cost;
    public Sprite sprite;
    public string shopDialog;
    public string ownerDialog;
    public string name;
}
