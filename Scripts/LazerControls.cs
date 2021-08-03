using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerControls : MonoBehaviour
{
    private int lazerSpeed = 10;
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Translate(Vector3.up * lazerSpeed * Time.deltaTime); 
        if(transform.position.y >= 14)
        {
            Destroy(this.gameObject, 1);
        }
    }
}
