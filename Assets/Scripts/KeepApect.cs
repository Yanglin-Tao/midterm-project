using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_IOS 
using UnityEngine.iOS;
#endif

public class KeepApect : MonoBehaviour
{
    // private Camera bgCam;
    // private Camera mainCam;

    // void Awake()
    // {
    //     bgCam = GetComponent<Camera>();
    //     mainCam = Camera.main;

    //     // float nineBy16 = 9f / 16f;
    //     float targetAspect = 576 / 1024;

    //     if (bgCam.aspect < targetAspect)
    //     {
    //         mainCam.rect = new Rect(0f, (1.0f - bgCam.aspect / targetAspect) / 2.0f, 1.0f, bgCam.aspect / targetAspect);

    //     }
    //     else if (bgCam.aspect > targetAspect)
    //     {
    //         mainCam.rect = new Rect((1.0f - targetAspect / bgCam.aspect) / 2.0f, 0, targetAspect / bgCam.aspect, 1.0f);
    //     }
    // }

    void Start () 
    {
        // set the desired aspect ratio (the values in this example are
        // hard-coded for 16:9, but you could make them into public
        // variables instead so you can set them at design time)
        float targetaspect = 1024 / 576;

        // determine the game window's current aspect ratio
        float windowaspect = (float)Screen.width / (float)Screen.height;

        // current viewport height should be scaled by this amount
        float scaleheight = windowaspect / targetaspect;

        // obtain camera component so we can modify its viewport
        Camera camera = GetComponent<Camera>();

        // if scaled height is less than current height, add letterbox
        if (scaleheight < 1.0f)
        {  
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;
            
            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }
}