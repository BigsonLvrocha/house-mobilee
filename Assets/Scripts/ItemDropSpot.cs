using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropSpot : MonoBehaviour {

	public GameManager gm;
	public FurnitureScriptable expectedItem;

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
	}
}