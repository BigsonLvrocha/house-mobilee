using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string destinyScene;

    private void  OnMouseDown() 
    {
        GameManager.Manager.LoadScene(this.destinyScene);
    }
}