using System.Collections;
using UnityEngine;

public class DebugController : MonoBehaviour {

	public DialogManager dm;
	Dialogue dialog = null;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){

        
        if (Input.GetKeyDown(KeyCode.D)) {
    		Debug.Log("Creating dialog");

        	dialog = new Dialogue(new string[]{
				"Primeira frase", 
				"frase 2", 
				"outra frase muito mais longa pra ver o tamanho das coisas aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa nao sei o que escrever aqui mas vai ser longo", 
				"bizarro", 
				"FIM"
			});
	        
	        dm.Reset();
	        dm.StartDialog(dialog, "Debug Voice", null);

        }

        else if (Input.GetButtonDown("Action")) {
        	if (dm.dialogRunning){
        		dm.NextSentence();
        	}
        }

        if (Input.GetButton("Cancel")) {
        	if (dm.dialogRunning){
        		dm.fastText = !dm.fastText;
        	}
        }
    }
}
