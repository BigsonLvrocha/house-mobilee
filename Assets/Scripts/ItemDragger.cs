
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragger : MonoBehaviour {

	public ShopItem reference;

	void Update () {

		if (Input.GetMouseButtonUp(0)) this.OnPointerUp();

		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		this.transform.position = new Vector2(mousePos.x, mousePos.y);
	}

	public void OnPointerUp() {
		Debug.Log("Mouse is up");
		this.reference.ReturnToShop();
		Destroy(this.gameObject);
	}
}