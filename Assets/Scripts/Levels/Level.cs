using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	public GameManager gm;
    public ItemDropSpot[] dropSpots { get; protected set; }

    [UnityEngine.SerializeField]
	protected int _topScore = 90;
	public int topScore 
		{ 
			get { return this._topScore; } 
			protected set { 
				this.initialMoney = Mathf.CeilToInt(value/2);
				this._topScore = value; 
			}
		}

    [UnityEngine.SerializeField]
	protected int _initialMoney = 90;
	public int initialMoney 
		{ 
			get { return this._initialMoney; } 
			private set { this._initialMoney = value; }
		}

    [UnityEngine.SerializeField]
	protected string[] _correctItems;
	public string[] correctItems 
		{ 
			get { return this._correctItems; } 
			protected set { this._correctItems = value; }
		}

    [UnityEngine.SerializeField]
	protected List<Furniture> _shopList;
	public List<Furniture> shopList 
		{ 
			get { return this._shopList; } 
			protected set { this._shopList = value; }
		}


    public List<Furniture> GetShopList(){
    	return new List<Furniture>(this.shopList.ToArray());
    }

    void Start() {
    	
    	// this.initialMoney = Mathf.CeilToInt(this.topScore/2);
    	this.dropSpots = Object.FindObjectsOfType<ItemDropSpot>();
    	this.topScore = this.dropSpots.Length*2;
    	print(this.dropSpots[0]);
    	
    	this.gm = GameObject.FindObjectOfType<GameManager>();
    	print(this.initialMoney);
        this.gm.money = this.initialMoney;
        this.gm.level = this;

    }

    void Update(){

		if (this.gm.money == 0)    {

    		foreach (ItemDropSpot item in this.dropSpots)
    			if (item.gotItem == null)
    				return;

    		// All spots are populated
    		gm.WinOrLose();
		}
    }
}
