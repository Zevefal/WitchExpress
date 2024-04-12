using Agava.WebUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrientation : MonoBehaviour
{
    private void Awake()
    {
        if (Device.IsMobile)
        {
            Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
        }
        else
        {
            Screen.orientation = UnityEngine.ScreenOrientation.LandscapeLeft;
        }

        Debug.Log("DEVICE TYPE" + Device.IsMobile);
    }    
}
