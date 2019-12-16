using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 제작 : 신동규
 * 가까이 오면 도망가고 아이템을 가져오면 가까이 오며 상호작용하는 동물에 대한 코드입니다.
 * 각 상황별 거리를 조정할 수 있습니다(DIstance)
 * 상호작용할 플레이어와 아이템이 필요합니다.
 */

public class RabbitInteractive : MonoBehaviour
{
    public GameObject Player;              //상호작용할 객체 (플레이어)
    public GameObject Item;                //상호작용할 객체 (아이템)
    public float moveSpeed = 2;            //이동속도
    public float InDistance = 5;           //접근 거리
    public float OutDistance = 7;          //도망 거리
    public float InteractiveDistance = 1;  //상호작용 거리
    public float DistanceOfKeeping = 2;    //아이템을 가지고 있는지 판단하는 거리
    private bool IsRunAway = false;        //도망 여부
    private bool IsTrace = false;          //아이템 여부
    private bool IsInteractive = false;         //상호작용 여부

    // Start is called before the first frame update
    void Start()        //초기화
    {
        IsRunAway = false;              //도망 여부
        IsTrace = false;                //추격 여부
        IsInteractive = false;          //상호작용 여부
        this.GetComponent<Animator>().SetBool("IsRun", false);              //애니메이션 변경 (멈춤)
        this.GetComponent<Animator>().SetBool("IsInteractive", false);      //애니메이션 변경 (멈춤)
    }

    //조건 충족시 한번씩 실행
    private void FixedUpdate()
    {
        if (Vector3.Distance(Item.transform.position, this.transform.position) <= InteractiveDistance)
        {       //아이템과 상호작용 거리 내에 있을 시, 상호작용을 한다.
            this.GetComponent<Animator>().SetBool("IsRun", false);        //애니메이션 변경 (멈춤)
            this.GetComponent<Animator>().SetBool("IsInteractive", true);      //애니메이션 변경 (먹기)
            IsRunAway = false;      //도망 여부
            IsTrace = false;        //추격 여부
            IsInteractive = true;        //상호작용 여부
            return;
        }
        if (Vector3.Distance(Item.transform.position, this.transform.position) <= InDistance)       //아이템에 가까워지면 다가온다.
        {
            this.GetComponent<Animator>().SetBool("IsInteractive", false);    //애니메이션 변경 (멈춤)
            this.GetComponent<Animator>().SetBool("IsRun", true);        //애니메이션 변경 (달리기)
            IsRunAway = false;      //도망 여부
            IsTrace = true;         //추격 여부
            IsInteractive = false;       //상호작용 여부
            return;
        }
        if (Vector3.Distance(Player.transform.position, this.transform.position) <= InDistance && Vector3.Distance(Player.transform.position, Item.transform.position) > DistanceOfKeeping)
        {       //플레이어가 다가오면 도망간다, 아이템을 소지하고 있다면 도망가지 않는다.
            this.GetComponent<Animator>().SetBool("IsInteractive", false);    //애니메이션 변경 (멈춤)
            this.GetComponent<Animator>().SetBool("IsRun", true);        //애니메이션 변경 (달리기)
            IsRunAway = true;       //도망 여부
            IsTrace = false;        //추격 여부
            IsInteractive = false;       //상호작용 여부
            return;
        }
        if (Vector3.Distance(Player.transform.position, this.transform.position) >= OutDistance && Vector3.Distance(Item.transform.position, this.transform.position) >= OutDistance)
        {       //아이템도 플레이어도 근처에 없을 시 멈춰있는다.
            this.GetComponent<Animator>().SetBool("IsRun", false);        //애니메이션 변경 (멈춤)
            this.GetComponent<Animator>().SetBool("IsInteractive", false);    //애니메이션 변경 (멈춤)
            IsRunAway = false;      //도망 여부
            IsTrace = false;        //추격 여부
            IsInteractive = false;       //상호작용 여부
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInteractive == false)      //상호작용 하지 않을 때
        {
            if (IsRunAway == true)        //도망칠 때
            {
                this.transform.LookAt(2 * this.transform.position - Player.transform.position);         //반대방향을 바라본다.
                this.transform.rotation = Quaternion.Euler(0, this.transform.eulerAngles.y, 0);         //수직방향 고정
                                                                                                        //수평방향으로만 움직이기 위한 코드이므로 수직방향도 사용할 시 윗줄만 주석처리를 하면 된다.
                this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);     //이동속도에 따라 앞으로 이동
            }
            else
            {
                if (IsTrace == true)        //다가올 때
                {
                    this.transform.LookAt(Item.transform.position);                                         //반대방향을 바라본다.
                    this.transform.rotation = Quaternion.Euler(0, this.transform.eulerAngles.y, 0);         //수직방향 고정
                                                                                                            //수평방향으로만 움직이기 위한 코드이므로 수직방향도 사용할 시 윗줄만 주석처리를 하면 된다.
                    this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);     //이동속도에 따라 앞으로 이동
                }
            }
        }
        else
        {
            Vector3 dir = new Vector3(Item.transform.position.x, this.transform.position.y, Item.transform.position.z);     //수직방향 고정
            this.transform.LookAt(dir);     //쳐다보기
        }
    }
}
