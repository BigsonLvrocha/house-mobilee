using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	public LevelBase level;
	public Button openBtn;
	public Button closeBtn;
	public GameObject contentObject;

	private bool _isopen;
	public bool isopen { get { return this._isopen; } }

	public List<Furniture> shopList;

	public void Start() {
		
		this.shopList = new List<Furniture>(
			this.contentObject.GetComponentsInChildren<Furniture>()
		);
		this.level = GameObject.FindObjectOfType<LevelBase>();
		this.CloseShop();
	}

	public void SetShopState(bool state, string btnText){

		foreach (Transform child in this.transform)
			child.gameObject.SetActive(state);

		this.openBtn.gameObject.SetActive(!state);
		this.closeBtn.gameObject.SetActive(state);

		this._isopen = state;
	}

	public void CloseShop(){
		SetShopState(false, "Open Shop");
		// this.btn.onClick.AddListener(OpenShop); Unity doesnt like adding events :c
	}

	public void OpenShop(){
		SetShopState(true, "Close Shop");
		// this.btn.onClick.AddListener(CloseShop);
	}

}