/**********************************

* 프로그램명 : Moving.cs

* 작성자 : 정선우

* 작성일 : 2019년 11월27일

* 프로그램 설명 : 행성이 태양을 중심으로 원운동하는 것을 구현.
                 에디터에서 기준 행성과 스피드를 설정할 수 있게 함.

***********************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Planet;       //기준행성
    public float speed;             //회전 속도

    private void Update()
    {
        OrbitAround();
    }

    void OrbitAround()
    {
        transform.RotateAround(Planet.transform.position, Vector3.down, speed * Time.deltaTime);
    }
    //                  기준점         방향           속도
    // RotateAround(Vector3 point, Vector3 axis, float angle)
}
