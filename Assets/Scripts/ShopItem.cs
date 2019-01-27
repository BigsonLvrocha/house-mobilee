using UnityEngine;
using UnityEngine.EventSystems;

public class ShopItem : MonoBehaviour, IPointerDownHandler {

	[UnityEngine.SerializeField]
	private GameObject prefab;

	private Vector3 _originalPosition;
	private GameManager gm;
	private Shop shop;

	void Awake() {
		this.gm = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	void Start() {
		this.shop = this.GetComponentInParent<Shop>();
	}

	// Maybe use only mouse down?
	public void OnPointerDown(PointerEventData eventData) {
		Debug.Log("Mouse is down, instantiating object");
        /*
		// Detract cost from player's money
		try {
			//this.gm.money -= furniture.cost;
		} catch (ArgumentException e){
			// Not enought money
			return;
		}
        */
		// Create new
		var newObj = GameObject.Instantiate(this.prefab);
		
		// Get object's furniture reference and copy this values
		var furniture = newObj.GetComponent<Furniture>();
		furniture.obj = this.GetComponent<Furniture>().obj;

		// Get object's dragger
		var dragger = newObj.GetComponent<ItemDragger>();
		dragger.reference = this;

		// Disable shop and this to remove from shop list
		this.shop.CloseShop();
		this.gameObject.SetActive(false);
	}

	public void ReturnToShop(){
		this.gm.money += this.GetComponent<Furniture>().obj.cost;
		this.gameObject.SetActive(true);
		this.shop.OpenShop();
	}

	// public void OnEndDrag(PointerEventData eventData) {
	// 	this.transform.position = this._originalPosition;
	// }
}