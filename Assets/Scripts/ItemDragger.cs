
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragger : MonoBehaviour {

	public ShopItem reference;
	public ItemDropSpot[] dropSpots;

	void Update () {

		if (Input.GetMouseButtonUp(0)) this.OnPointerUp();
		else {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			this.transform.position = new Vector2(mousePos.x, mousePos.y);
		}
	}

	void Snap(Vector3 position){
		Debug.Log("Snapping to " + position + " yay");
		this.gameObject.transform.position = position;
		GameObject.Destroy(this);
	}

	public void OnPointerUp() {
		Debug.Log("Mouse is up");

		foreach (ItemDropSpot spot in this.dropSpots) {
			
			Debug.Log("Spot " + spot.expectedItem.name);
			Debug.Log(spot.transform.position + " " + this.transform.position);
			Vector2 dist = (Vector2) spot.transform.position - (Vector2) this.transform.position;
			Debug.Log(dist.magnitude);
			Debug.Log(" ");
			
			// Valid snap spot
			if(dist.magnitude <= 1){
				this.Snap(spot.transform.position);
				spot.gotItem = GetComponent<Furniture>();
				return;
			}
		}

		// No close snap spot found
		this.reference.ReturnToShop();
		Destroy(this.gameObject);
	}
}