using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 제작 : 신동규
 * 적용 객체가 방향키에 따라 이동하는 코드입니다.
 */

public class FixedMovementController : MonoBehaviour
{
    private float h = 0.0f;     //좌우 입력값
    private float v = 0.0f;     //앞뒤 입력값

    // 접근해야 하는 컴포넌트는 반드시 변수에 할당한 후 사용
    [SerializeField] private Transform tr;
    public float moveSpeed = 10.0f;     // 이동 속도
    public GameObject Camera;           //카메라

    // Use this for initialization
    void Start()
    {
        // Transform 컴포넌트를 할당
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0, Camera.transform.eulerAngles.y, 0);   //수직방향 고정

        h = Input.GetAxis("Horizontal");    //좌우 입력
        v = Input.GetAxis("Vertical");      //앞뒤 입력

        Debug.Log("h=" + h.ToString());
        Debug.Log("v=" + v.ToString());

        // 전후좌우 이동 방향 벡터 계산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        // Translate(이동 방향 * 속도 + Time.deltaTime, 기준좌표)
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);
    }
}