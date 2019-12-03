/************************************

* 프로그램명 : SelfMoving.cs

* 작성자 : 정선우

* 작성일 : 2019년 11월27일

* 프로그램 설명 : 행성의 자전을 실행하기 위한 스크립트.
                 회전하는 함수를 사용했다.

***********************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfMoving : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;        //회전속도
    private void Update()
    {
        Orbit_Rotation();
    }

    void Orbit_Rotation()
    {
        transform.Rotate(Vector3.down * speed * Time.deltaTime);
        //transform.Rotate(Vector3 EularAngle)
    }
}
