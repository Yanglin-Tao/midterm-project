using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryInY : MonoBehaviour
{
    public float yLimit = 20;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < yLimit){
            Destroy(gameObject);
        }
    }
}
