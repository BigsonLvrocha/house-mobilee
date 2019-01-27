using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Furniture : MonoBehaviour {

	/* Properties */
	public FurnitureScriptable obj;

	// Readonly access fields for scriptable object
	public int cost				{ get { return this.obj.cost;		 } }
    public Sprite sprite		{ get { return this.obj.sprite;		 } }
    public string name			{ get { return this.obj.name;		 } }
    public string shopDialog	{ get { return this.obj.shopDialog;	 } }
    public string ownerDialog	{ get { return this.obj.ownerDialog; } }

	public void Start() {
		
		// Working on scene
		try {
			this.GetComponentInChildren<SpriteRenderer>().sprite = this.sprite;

		// Working on UI
		} catch (NullReferenceException e){
			this.GetComponentInChildren<Image>().sprite = this.sprite;
			this.GetComponentInChildren<Text>().text = this.shopDialog;
		}
	}

	public void SetScriptableObject(FurnitureScriptable obj){
		this.obj = obj;
	}
}