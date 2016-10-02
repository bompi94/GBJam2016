using UnityEngine;
using System.Collections;

public class ResolutionLimiter : MonoBehaviour
{
    public int h = 144;
    public int w = 160;
    public int multiplier = 10; 

    public void Start()
    {  
        Screen.SetResolution(w*multiplier, h*multiplier, false);
        Screen.fullScreen = true; 
    }

}