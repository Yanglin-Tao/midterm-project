using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifespan : MonoBehaviour
{
    public float lifeTime = 2;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}