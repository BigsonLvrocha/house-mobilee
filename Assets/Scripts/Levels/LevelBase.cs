using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBase : MonoBehaviour {
    
    [UnityEngine.SerializeField]
	protected int initialMoney;
    [UnityEngine.SerializeField]
	protected List<Furniture> shopList;
    [UnityEngine.SerializeField]
	protected string[] correctItems;

    public List<Furniture> GetShopList(){
    	return new List<Furniture>(this.shopList.ToArray());
    }
}
