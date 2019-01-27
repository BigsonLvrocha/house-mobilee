using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenTimer : MonoBehaviour
{
    public float timeForTransit = 3;
    private float elapsedTime = 0f;
    public string NextScene = "";
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
       this.elapsedTime += Time.deltaTime;
       if (this.elapsedTime > timeForTransit) {
           GameManager.Manager.LoadScene(this.NextScene);
       } 
    }
}
