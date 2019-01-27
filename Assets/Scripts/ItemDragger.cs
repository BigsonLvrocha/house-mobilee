
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragger : MonoBehaviour {

	public bool dragOn;
	public ShopItem reference;
	public ItemDropSpot[] dropSpots;

	void Start() {
		Debug.Log("On Start()");
		Debug.Log(dragOn);
		Debug.Log(reference);
	}

	void Update () {
		if(!dragOn) {
			return;
		}
		CameraMan.paused = true;
		if (Input.GetMouseButtonUp(0)) {
			print("Item Dragger button up");
			this.OnPointerUp();
		} else {
			print("Dragging");
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Debug.Log("Moving to " + mousePos);
			this.transform.position = new Vector2( (int) mousePos.x, (int) mousePos.y);
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