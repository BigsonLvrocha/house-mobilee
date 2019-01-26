using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private int money;

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
        }
        this.LoadScene(this.currentScene);
    }

    public void LoadScene(string scene)
    {
        this.currentScene = scene;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene);
    }
}
