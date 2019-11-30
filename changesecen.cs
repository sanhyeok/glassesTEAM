/***********************************

* 프로그램명 : changesecen.cs

* 작성자 : 정선우

* 작성일 : 2019년 11월27일
* 수정일 : 2019년 11월30일

* 프로그램 설명 : 조건에 맞게 실행하고 있는 secen을 바꾼다.
                 맵 이동에 사용.

***********************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class changesecen : MonoBehaviour
{
    private int Scene_index = 0;
    public List<GameObject> dest; // 목적지
    // Start is called before the first frame update
    void Start()
    {
    }
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);  // index에 해당하는 scene을 호출한다.
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, dest[Scene_index].transform.position) < 10)  // 목적지에 다다르면
        {
            Scene_index += 1;
            LoadScene(Scene_index);
        }// 다음 인덱스의 씬으로 이동
    }
}
