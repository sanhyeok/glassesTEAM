using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 제작 : 신동규
 * 정해진 객체가 접근할 때 새가 반대 방향으로 날아가는 코드입니다.
 * 접근 기준점은 Player 객체, 적용 객체가 도망갑니다.
 */

public class RunAwayBirdControll : MonoBehaviour
{
    public GameObject Player;               //상호작용할 객체 (거리 기준점)
    public string terrain;                  //내려앉을 지형 이름
    public float moveSpeed = 2;             //이동속도
    public float InDistance = 4;            //접근 거리
    public float OutDistance = 7;           //도망 거리
    private bool IsRunAway = false;         //도망 여부
    private bool Island = true;             //착지 여부

    // Start is called before the first frame update
    void Start()
    {

    }

    //조건 충족시 한번씩 실행
    private void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, Player.transform.position) <= InDistance)       //정해진 거리만큼 접근 시
        {
            IsRunAway = true;       //도망감
        }
        if (Vector3.Distance(this.transform.position, Player.transform.position) > OutDistance)      //거리 밖일 경우
        {
            IsRunAway = false;      //멈춤
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == terrain)
        {
            this.GetComponent<Animator>().SetBool("IsFly", false);      //애니메이션 변경 (멈춤)
            Island = true;                                              //착지상태가 됨
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == terrain)
        {
            this.GetComponent<Animator>().SetBool("IsFly", true);       //애니메이션 변경 (날기)
            Island = false;                                             //착지상태가 아님
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRunAway == true)        //정해진 거리만큼 접근 시
        {
            this.transform.LookAt(2 * this.transform.position - Player.transform.position);         //반대방향을 바라본다.
            this.transform.rotation = Quaternion.Euler(0, this.transform.eulerAngles.y, 0);         //수직방향 고정
            //수평방향으로만 움직이기 위한 코드이므로 수직방향도 사용할 시 윗줄만 주석처리를 하면 된다.
            this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);     //이동속도에 따라 앞으로 이동
            this.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);          //이동속도에 따라 위로 이동
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);                         //속도 고정
        }
        else
        {
            if (Island == false)
            {
                this.transform.LookAt(2 * this.transform.position - Player.transform.position);         //반대방향을 바라본다.
                this.transform.rotation = Quaternion.Euler(0, this.transform.eulerAngles.y, 0);         //수직방향 고정
                                                                                                        //수평방향으로만 움직이기 위한 코드이므로 수직방향도 사용할 시 윗줄만 주석처리를 하면 된다.
                this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);     //이동속도에 따라 앞으로 이동
                this.transform.Translate(Vector3.down * moveSpeed/2.0f * Time.deltaTime, Space.Self);   //이동속도의 반 속도로 아래로 이동
                this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);                         //속도 고정
            }
            else
            {

            }
        }
    }
}
