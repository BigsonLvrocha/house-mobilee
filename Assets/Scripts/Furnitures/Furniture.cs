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
    public GameObject sprite	{ get { return this.obj.spritePrefab;} }
    public GameObject images	{ get { return this.obj.imagesPrefab;} }
    public string name			{ get { return this.obj.name;		 } }
    public string shopDialog	{ get { return this.obj.shopDialog;	 } }
    public string ownerDialog	{ get { return this.obj.ownerDialog; } }

	public void Start() {
		
		// Set shop text
		this.GetComponentInChildren<Text>().text = this.shopDialog;

		// Find all images/sprites
		Transform sprites = this.transform.Find("Sprites");
		Transform images = this.transform.Find("Images");

		// Repalce prefab's images/sprites with this obj's images/sprites
		foreach (Transform child in images)
			GameObject.Destroy(child.gameObject);

		foreach (Transform child in sprites)
			GameObject.Destroy(child.gameObject);

		Instantiate(this.images, sprites);
		Instantiate(this.sprite, sprites);
	}

	public void SetScriptableObject(FurnitureScriptable obj){
		this.obj = obj;
	}
}