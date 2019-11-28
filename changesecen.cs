using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class changesecen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            LoadScene("test1");
        if (Input.GetMouseButtonDown(1))
            LoadScene("SampleScene");
    }
}
