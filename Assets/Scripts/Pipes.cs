using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
   public float speed = 5f;
   public float leftEdge;

    private void Start(){
        leftEdge = Camera.main.ScreenToWorldPoint(new Vector3(0,0,0)).x - 0.5f;
    }
    void Update() 
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if(transform.position.x < leftEdge){
            Destroy(gameObject);
        }
    }
}
