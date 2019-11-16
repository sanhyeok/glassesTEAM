using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMovementController : MonoBehaviour
{
    private float h = 0.0f;
    private float v = 0.0f;
    private float r = 0.0f;

    // 접근해야 하는 컴포넌트는 반드시 변수에 할당한 후 사용
    [SerializeField] private Transform tr;

    // 이동 속도 변수(public으로 선언되어 Inspector에 노출됨
    public float moveSpeed = 10.0f;
    // 회전 속도 변수
    public float rotSpeed = 80.0f;

    public GameObject Camera;

    // Use this for initialization
    void Start()
    {
        // Transform 컴포넌트를 할당
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0, Camera.transform.eulerAngles.y, 0);

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        Debug.Log("h=" + h.ToString());
        Debug.Log("v=" + v.ToString());

        // 전후좌우 이동 방향 벡터 계산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        // Translate(이동 방향 * 속도 + Time.deltaTime, 기준좌표)
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);

        
    }
}