using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Animation>().Play("flyNormal");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
