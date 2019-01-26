using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class CameraMan : MonoBehaviour
{
    public float dragSpeed = 2;
    public float debounce = 0.2f;

    public float lerp = 0.6f;
    private Vector3 dragOrigin;
    private float timePassed = 0.0f;
    
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.timePassed = 0.0f;
            dragOrigin = Input.mousePosition;
            return;
        }
    
        if (!Input.GetMouseButton(0)) return;
        this.timePassed += Time.deltaTime;
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        this.dragOrigin = Vector3.Lerp(this.dragOrigin, Input.mousePosition, this.lerp);
        Vector3 move = new Vector3(-pos.x * dragSpeed, -pos.y * dragSpeed, 0);
    
        transform.Translate(move, Space.World);  
    }
}
