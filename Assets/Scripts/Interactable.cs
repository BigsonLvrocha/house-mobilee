using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour {

	public Sentence[] sentences;
	private DialogManager dm;

	void Start() {
		this.dm = FindObjectOfType<DialogManager>();
	}

	void Update() { 
		if (this.dm.dialogRunning && Input.GetMouseButtonDown(0)){
			this.dm.NextSentence();
		}
	}

    public void OnMouseDown(){
    	if(this.dm.dialogRunning){
    		return;
    	} else {
	    	var dialog = new Dialogue(sentences);
	    	this.dm.StartDialog(dialog, "", null);
    	}
    }
}
