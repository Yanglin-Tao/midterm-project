using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_IOS 
using UnityEngine.iOS;
#endif

public class KeepApect : MonoBehaviour
{
    private Camera bgCam;
    private Camera mainCam;

    void Awake()
    {
        bgCam = GetComponent<Camera>();
        mainCam = Camera.main;

        // float nineBy16 = 9f / 16f;
        float targetAspect = 576 / 1024;

        if (bgCam.aspect < targetAspect)
        {
            mainCam.rect = new Rect(0f, (1.0f - bgCam.aspect / targetAspect) / 2.0f, 1.0f, bgCam.aspect / targetAspect);

        }
        else if (bgCam.aspect > targetAspect)
        {
            mainCam.rect = new Rect((1.0f - targetAspect / bgCam.aspect) / 2.0f, 0, targetAspect / bgCam.aspect, 1.0f);
        }
    }
}