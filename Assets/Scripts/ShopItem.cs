using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopItem : MonoBehaviour, IPointerDownHandler {

	[UnityEngine.SerializeField]
	private GameObject prefab;

	private Vector3 _originalPosition;
	private GameManager gm;
	private Shop shop;

	void Awake() {
		this.gm = GameObject.FindObjectOfType<GameManager>();
	}

	void Start() {
		this.shop = this.GetComponentInParent<Shop>();
	}

	// Maybe use only mouse down?
	public void OnPointerDown(PointerEventData eventData) {
		Debug.Log("Mouse is down, instantiating object");

		// Create new
		var newObj = GameObject.Instantiate(this.prefab);
		GameObject.Destroy(newObj.GetComponent<ShopItem>());

		// Get object's furniture reference and copy this values
		var furniture = newObj.GetComponent<Furniture>();
		
		// Try to detract cost from player's money
		try { this.gm.money -= furniture.cost; } 
		catch (ArgumentException e){ return; } // Not enought money

		furniture.obj = this.GetComponent<Furniture>().obj;

		// Get object's dragger
		// var dragger = newObj.GetComponent<ItemDragger>();
		Debug.Log("Adicionando dragger");
		var dragger = newObj.AddComponent<ItemDragger>();
		dragger.dragOn = true;
		dragger.reference = this;
		dragger.dropSpots = shop.level.dropSpots;
		Debug.Log("On instantiate");
		Debug.Log(dragger.dragOn);
		Debug.Log(dragger.reference);

		// Disable shop and this to remove from shop list
		this.shop.CloseShop();
		this.gameObject.SetActive(false);
	}

	public void ReturnToShop(){
		print("Returning to Shop");
		this.gm.money += this.GetComponent<Furniture>().obj.cost;
		this.gameObject.SetActive(true);
		this.shop.OpenShop();
	}

	// public void OnEndDrag(PointerEventData eventData) {
	// 	this.transform.position = this._originalPosition;
	// }
}