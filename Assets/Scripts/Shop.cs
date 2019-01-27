using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	private GameManager gm;

	public Level level;
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
		this.level = GameObject.FindObjectOfType<Level>();
		this.gm = FindObjectOfType<GameManager>();
		this.CloseShop();
	}

	public void SetShopState(bool state){

		foreach (Transform child in this.transform)
			child.gameObject.SetActive(state);

		this.openBtn.gameObject.SetActive(!state);
		this.closeBtn.gameObject.SetActive(state);

		this._isopen = state;
		print("state " + state);
		CameraMan.paused = state;
	}

	public void CloseShop(){
		SetShopState(false);
		// this.btn.onClick.AddListener(OpenShop); Unity doesnt like adding events :c
	}

	public void OpenShop(){
		SetShopState(true);
		// this.btn.onClick.AddListener(CloseShop);
	}

}