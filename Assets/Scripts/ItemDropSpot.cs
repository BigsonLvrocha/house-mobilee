using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropSpot : MonoBehaviour {

	public GameManager gm;
	public FurnitureScriptable expectedItem;
	public bool showShadow;

	private Furniture _gotItem;
	public Furniture gotItem {
		get { return this._gotItem; }
		set {
			if (this.expectedItem.name == value.name) Debug.Log("Item certo");
			else Debug.Log("Item Errado");
			this._gotItem = value;
		}
	}

	void Start(){
		if(!this.gm){
			this.gm = FindObjectOfType<GameManager>();
		}
		if (showShadow){
			var t = Instantiate(this.expectedItem.spritePrefab, this.transform);
			foreach (Transform child in t.transform) {
				var sprite = child.GetComponent<SpriteRenderer>();
				sprite.color = new Color(1f, 1f, 1f, 0.5f);
			}
		}
	}
}