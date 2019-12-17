using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 제작 : 신동규
 * 적용 객체가 정해진 경로에 따라 이동하게 하는 코드입니다.
 * waypoint리스트의 크기를 설정하고 위치정보를 가진 객체(빈 오브젝트)를 만들어서
 * waypoint 배열에 경로 순서대로 대입 시 경로 선이 보이고 그 경로대로 움직입니다.
 */

public class AutoMove : MonoBehaviour
{
    public int currentNode = 0;     //현재 목적지. 값을 입력할 경우 그 waypoint를 첫 목적지로 삼습니다.
    public List<Transform> waypoint = new List<Transform>();  //위치정보를 가지고 있는 리스트 선언.
    public float moveSpeed = 3;     //이동속도
    public float InNodeDistance = 3;     //이동속도
    public bool XZFreezing = true;  //xz방향 고정 여부
    public bool roundTrip = true;   //왕복 여부
    private Transform me;           //임시 방향

    // Start is called before the first frame update
    void Start()
    {
        me = this.transform;        //초기화
    }

    // Update is called once per frame
    void Update()       //목표물을 향해 움직임
    {
        if (XZFreezing == true)
        {
            this.transform.LookAt(waypoint[currentNode].position);      //목적지를 향하게 함
            this.transform.rotation = Quaternion.Euler(0, this.transform.eulerAngles.y, 0);     //수직방향 고정
        }       //수평방향으로만 움직이기 위한 코드이므로 수직방향도 사용할 시 xzFreezing을 false 하면 된다.
        if (XZFreezing == false)
        {
            me.rotation = Quaternion.LookRotation(waypoint[currentNode].position - this.transform.position);        //목적지를 향하는 방향 계산
            this.transform.rotation = Quaternion.Euler(me.rotation.eulerAngles.x, this.transform.eulerAngles.y, me.rotation.eulerAngles.z);     //xz축 방향 유지
        }
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);     //이동속도에 따라 이동
    }

    void FixedUpdate()
    {
        if (currentNode == waypoint.Count && roundTrip == true)  //마지막 노드(웨이포인트)로 도착하였을 때는 초기화 시켜준다.
            currentNode = 0;                //(여기선 처음 노드로 초기화하여 반복 이동시킴, 사용에 따라 편도이동 할 수 있음)
        if (Vector3.Distance(this.transform.position, waypoint[currentNode].position) <= InNodeDistance)      //목적지 도착시
        {
            GotoNext();     //목적지까지의 거리가 1이하(도착)면 함수실행 -> 다음 목적지를 설정함
        }
    }

    void GotoNext()
    {
        
        currentNode = (currentNode + 1);
        //다음 노드로 목표 변경
        //도착시 추가 사항은 여기에 입력
    }

    private void OnDrawGizmos()     //기즈모, 웨이포인트 간에 선을 그림
    {
        for (int i = 0; i < waypoint.Count; i++)
        {
            Gizmos.color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
            Gizmos.DrawSphere(waypoint[i].transform.position, 2);
            Gizmos.DrawWireSphere(waypoint[i].transform.position, 20f);
            //웨이포인트에 구를 그림

            if (i < waypoint.Count - 1)
            {
                if (waypoint[i] && waypoint[i + 1])
                {
                    Gizmos.color = Color.red;
                    if (i < waypoint.Count - 1)
                        Gizmos.DrawLine(waypoint[i].position, waypoint[i + 1].position);
                    if (i < waypoint.Count - 2)
                    {
                        Gizmos.DrawLine(waypoint[waypoint.Count - 1].position, waypoint[0].position);
                    }
                }
            }
            //웨이포인트 간에 선을 그림
        }
    }
}