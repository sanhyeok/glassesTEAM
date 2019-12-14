/***********************************

* 프로그램명 : changesecen.cs

* 작성자 : 정선우

* 작성일 : 2019년 11월27일
* 수정일 : 2019년 11월30일

* 프로그램 설명 : 조건에 맞게 실행하고 있는 secen을 바꾼다.
                  맵 이동에 사용.
                  다른 씬에서도 사용가능하게 목적지(Dest) 오브젝트를 설정
***********************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class changesecen : MonoBehaviour
{
    private int Scene_index = 0;
    private GameObject dest; // 목적지
    // Start is called before the first frame update
    void Awake()
    {
        Scene_index = SceneManager.GetActiveScene().buildIndex; // 실행중인 씬의 인덱스를 가져옴
        dest = GameObject.Find("Dest"); // Dest라는 오브젝트를 찾는다.
                                        // 다른 씬에서 오브젝트를 가져오지 못하기 때문에
                                        // 같은 이름의 오브젝트를 만들어서 위치 가져오기
    }
    
    private void LoadScene(int index)
    {
        SceneManager.LoadScene(index);  // index에 해당하는 scene을 호출한다.
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, dest.transform.position) < 10)  // 목적지에 다다르면
        {
            Scene_index++; // 다음 씬의 인덱스를 저장하고
            LoadScene(Scene_index); // 다음 씬을 불러온다.
        }
    }
}
