using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;        
using System.Reflection;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName="Furniture",menuName="Scriptable/Furnitures",order=1)]
public class FurnitureScriptable : ScriptableObject {
    public int cost;
    public Sprite sprite;
    public string shopDialog;
    public string ownerDialog;
    
    public FurnitureId entry;
    public string name {
    	get { return this.entry.GetDescription(); }
    }
}


public enum FurnitureId {

   [Description("Aquarium")] Aquarium,

}

/* Extension methods for Enum.FurnitureId */
public static class FurnituresDatabaseMethods{
	public static string GetDescription(this FurnitureId value){

		FieldInfo fi = value.GetType().GetField(value.ToString()); 

		DescriptionAttribute[] attrs = (DescriptionAttribute[]) 
			fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

		return (attrs.Length > 0) ? attrs[0].Description : value.ToString();
	}
}
