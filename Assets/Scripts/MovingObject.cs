using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed = 5;
    public float maxXPos = 0;
    public float minXPos = 0;


    void FixedUpdate()
    {
        // move from left to right and back forever
        // if moved for more than move_distance, turn and change direction on just x axis
        transform.position = new Vector2(transform.position.x + speed, transform.position.y);
        if (transform.position.x > maxXPos)
        {
            speed = -Mathf.Abs(speed);
            // get current localScale
            Vector3 localScale = transform.localScale;
            // flip x axis
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
        }
        else if (transform.position.x < minXPos)
        {
            speed = Mathf.Abs(speed);
            // get current localScale
            Vector3 localScale = transform.localScale;
            // flip x axis
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
        }
    }
}
