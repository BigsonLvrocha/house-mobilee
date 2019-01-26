using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	public Button openBtn;
	public Button closeBtn;

	private bool _isopen;
	public bool isopen { get { return this._isopen; } }

	[UnityEngine.SerializeField]
	private List<FurnitureId> shopList;

	public void Start() {
		this.shopList = new List<FurnitureId>();
		this.CloseShop();
	}

	public void AddItem(FurnitureId f) { this.shopList.Add(f); }
	public void AddItem(FurnitureId[] f) { this.shopList.AddRange(f); }
	public void AddItem(List<FurnitureId> f) { this.shopList.AddRange(f); }
	
	// public Furniture GetItemAt(int idx){
	// 	return this.shopList[idx];
	// }

	// This is dangerous, shoplist should be private -- need deepcopy
	// public List<Furniture> GetItemList(int idx){
	// 	foreach (FurnitureId id in this.shopList) {

		 	
	// 	}
	// }

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