/***********************************

* 프로그램명 : changesecen.cs

* 작성자 : 정선우

* 작성일 : 2019년 11월27일

* 프로그램 설명 : 조건에 맞게 실행하고 있는 secen을 바꾼다.
                 맵 이동에 사용.

***********************************/


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
