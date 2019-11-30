using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 제작 : 신동규
 * 지정된 객체를 기준으로 원을 그리며 이동하게 하는 코드입니다.
 * 원을 그리며 반복적으로 이동할 객체에 적용하세요.
 */

public class AutoMove_PlanetAround : MonoBehaviour
{
    public GameObject waypoint;         //위치정보를 가지고 있는 객체 선언. (기준 객체)
    public float moveSpeed = 3;         //이동속도

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(waypoint.transform.position, Vector3.down, moveSpeed * Time.deltaTime);
        //원을 그리며 이동하는 함수. 기준위치, 방향, 이동속도
    }

    private void OnDrawGizmos()     //기즈모, 웨이포인트를 그림
    {
        Gizmos.color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
        Gizmos.DrawSphere(waypoint.transform.position, 1);
        Gizmos.DrawWireSphere(waypoint.transform.position, 2);
        //기준점에 구를 그림
        Gizmos.DrawWireSphere(waypoint.transform.position, Vector3.Distance(this.transform.position, waypoint.transform.position));
        //경로에 선을 그림
    }
}