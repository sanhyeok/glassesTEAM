using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class soundonoff : MonoBehaviour
{
    public void soundedit()
    {
        AudioListener.pause = !AudioListener.pause;   
    }
}
