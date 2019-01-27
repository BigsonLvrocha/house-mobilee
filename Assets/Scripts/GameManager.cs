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
    public Level level;

    public AudioSource sound;

    [UnityEngine.SerializeField]
    private bool running = false;
    private int score = 0;
    private int _money;
    public int money {
        get { return this._money; }
        set {
            Debug.Log("Trying to set money to " + value);
            if (value < 0){
                // Debug.Log("0 or less money, end game");
                // WinOrLose();
                // return;
                throw new ArgumentException("Money cannot be less than 0");
            }
                
            Debug.Log("Money set");
            this._money = value;
            this.moneyText.text = this._money.ToString();
        }
    }

    private string currentScene = "";
    bool soundOn = true;

    public bool SoundOn 
    {
        get {
            return this.soundOn;
        }
        set {
            this.sound.mute = !value;
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

    public void Start()
    {
        this.sound = gameObject.GetComponent<AudioSource>();
    }

    public void WinOrLose(){
        if(!this.running) return;

        List<string> names = new List<string>();
        int counter = 0;

        print(this.level);
        print(this.level.dropSpots);
        foreach(ItemDropSpot item in this.level.dropSpots){
            // Items in correct position
            if (item.expectedItem.name == item.gotItem.name){
                counter++;
                this.score += 1;
            }

            // Create list of all expected items independent if its in correct place or not
            names.Add(item.expectedItem.name);
        }

        Debug.Log(counter + " items in correct place");
        counter = 0;

        foreach (ItemDropSpot item in this.level.dropSpots) {
            if(names.Contains(item.gotItem.name)){
                this.score += 1;
                counter++;
            }
        }

        Debug.Log(counter + " correct items");

        Debug.Log(this.score + " : " + this.level.topScore);
        if(this.score >= this.level.topScore){
            Debug.Log("PERFECT");
            // PerfectWin();
        } else if(this.score >= this.level.topScore/2){
            Debug.Log("Good.");
            // Win();
        } else {
            Debug.Log("Bad :c");
            // Lose();
        }
        this.running = false;
    }

    public void LoadScene(string scene)
    {
        this.currentScene = scene;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene);
        
        // this.level = GameObject.FindObjectOfType<Level>();
        print("Loaded new scene");
        print(this.level);
        if (this.level){
            this.money = this.level.initialMoney;
        }
        this.running = true;
    }

    public void NewGame()
    {
        Debug.Log("Called new game");
        this.LoadScene("Kitchen");
    }

    public void ReloadLevel(){
        this.score = 0;
        this.LoadScene(this.currentScene);
    }
}
