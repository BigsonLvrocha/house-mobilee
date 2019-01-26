using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    private Text buttonText;
    private GameManager man;
    // Start is called before the first frame update
    void Start()
    {
        this.man = GameManager.Manager;
        buttonText = this.gameObject.GetComponent<Text>();
        this.parseButtonText();
    }

    public void toggleSound()
    {
        this.man.SoundOn = !this.man.SoundOn;
        this.parseButtonText();
    }

    private void parseButtonText() 
    {
        this.buttonText.text = this.man.SoundOn ? "Sound - On" : "Sound - Off";
    }
}
