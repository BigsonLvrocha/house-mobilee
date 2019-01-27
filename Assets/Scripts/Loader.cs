using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject gameManager;       //GameManager prefab to instantiate.
    public GameObject dialogManager;     // DialogManager prefab to instantiate.
    
    void Awake ()
    {
        // Check if a GameManager has already been assigned to static variable 
        // GameManager.instance or if it's still null
        if (GameManager.Manager == null)
            //Instantiate gameManager prefab
            Instantiate(gameManager);
        
        if (DialogManager.Instance == null)
            Instantiate(dialogManager);
    }
}
