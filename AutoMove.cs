using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public int currentNode = 0;
    public List<Transform> waypoint = new List<Transform>();  //위치정보를 가지고 있는 리스트 선언.
    public float moveSpeed = 3;


    void Start()
    {
        
    }

    void Update()       //목표물을 향해 움직임
    {
        this.transform.LookAt(waypoint[currentNode].position);
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
        this.transform.rotation = Quaternion.Euler(0, this.transform.eulerAngles.y, 0);
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, waypoint[currentNode].position) < 2)
        {
            GotoNext();     //목적지까지의 거리가 2이하거나 도착했으면 함수실행
            this.GetComponent<Animator>().SetBool("IsWalk", true);
        }
        if (currentNode == waypoint.Count)  //마지막 노드 (웨이포인트)로 도착하였을 때는 초기화 시켜준다.
            currentNode = 0;                //(여기선 처음 노드로 초기화하여 반복시킴)
        if (Vector3.Distance(this.transform.position, waypoint[currentNode].position) < 10)
        {
            this.GetComponent<Animator>().SetBool("IsWalk", false);
        }
        //애니메이션 변경
    }

    void GotoNext()
    {
        
        currentNode = (currentNode + 1);
        //다음 노드로 목표 변경
    }

    private void OnDrawGizmos()     //기즈모, 웨이포인트 간에 선을 그림
    {
        for (int i = 0; i < waypoint.Count; i++)
        {
            Gizmos.color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
            Gizmos.DrawSphere(waypoint[i].transform.position, 2);
            Gizmos.DrawWireSphere(waypoint[i].transform.position, 20f);

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
        }
    }
}