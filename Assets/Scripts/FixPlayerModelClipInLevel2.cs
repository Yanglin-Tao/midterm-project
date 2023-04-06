using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPlayerModelClipInLevel2 : MonoBehaviour
{
    public float resetYPosition = -3.656244f;
    public float minXrange = 0;
    public float maxXrange = 0;
    public float clipTriggerYPosition = -3.656244f;

    // Update is called once per frame
    void Update()
    {
        // if player falls below a certain point and player in X range, reset to resetYPosition
        if (transform.position.y < clipTriggerYPosition && transform.position.x > minXrange && transform.position.x < maxXrange)
        {
            print(transform.position.y);
            transform.position = new Vector3(transform.position.x, resetYPosition, transform.position.z);
        }
    }
}
