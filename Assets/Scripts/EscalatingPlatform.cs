using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalatingPlatform : MonoBehaviour
{
    public float speed = 0.069f;
    public float maxYPos = 0;
    public float minYPos = 0;

    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + speed);
        if (transform.position.y > maxYPos)
        {
            speed = -Mathf.Abs(speed);
            // get current localScale
            Vector3 localScale = transform.localScale;
            // flip x axis
            transform.localScale = new Vector3(localScale.x, -localScale.y, localScale.z);
        }
        else if (transform.position.y < minYPos)
        {
            speed = Mathf.Abs(speed);
            // get current localScale
            Vector3 localScale = transform.localScale;
            // flip x axis
            transform.localScale = new Vector3(localScale.x, -localScale.y, localScale.z);
        }
    }
}
