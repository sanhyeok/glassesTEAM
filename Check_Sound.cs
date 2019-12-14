/***********************************

* 프로그램명 : Check_Sound.cs

* 작성자 : 정선우

* 작성일 : 2019년 12월 13일

* 프로그램 설명 : 충돌을 감지하여 충돌 발생시
*                 효과음 발생
***********************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Sound : MonoBehaviour
{
    public AudioSource audio;   // 효과음
    private void CrashPlayer(Collider other)
    {
        if (other.gameObject.tag == "Player") // 플레이어와 부딪히면
        {
            audio.Play();      // 효과음 재생
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        CrashPlayer(other); // 충돌체와 충돌시 플레이어와 충돌했는지 확인
    }
}
