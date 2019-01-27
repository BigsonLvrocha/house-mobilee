using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /* Statics */
    private static GameManager manager = null;
    public static GameManager Manager
    {
        get {
            return GameManager.manager;
        }
    }

    /* Properties */
    public Text moneyText;

    private int _money;
    public int money {
        get { return this._money; }
        set {
            if (value < 0)
                throw new ArgumentException("Money cannot be less than 0");
                
            this._money = value;
            this.moneyText.text = this._money.ToString();
        }
    }

    public string currentScene = "";
    bool soundOn = true;

    public bool SoundOn 
    {
        get {
            return this.soundOn;
        }
        set {
            this.soundOn = value;
        }
    }

    void Awake() {
        if (GameManager.manager == null) {
            GameManager.manager = this;
        } else if (GameManager.manager != this) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        if (this.currentScene == "") {
            this.LoadScene("Initial");
            return;
        }
        this.LoadScene(this.currentScene);
    }

    public void LoadScene(string scene)
    {
        this.currentScene = scene;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene);
    }

    public void NewGame()
    {
        this.LoadScene("Kitchen");
    }
}
