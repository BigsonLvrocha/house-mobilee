using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : LevelBase {
    
    // Start is called before the first frame update
    void Start() {
        var gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.money = this.initialMoney;
    }

    // Update is called once per frame
    void Update() {
        
    }
}
