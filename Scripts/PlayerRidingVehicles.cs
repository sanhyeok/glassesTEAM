using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 제작 : 신동규
 * 탈것에 타고 내리는 것과 탈것 주변으로 이동이 제한되는 코드입니다.
 * 탈것 객체와 벽 객체를 먼저 지정해야합니다.
 * 탑승 시 탈것과 정해진 거리내로 있어야 탑승가능합니다. 이 거리는 vaildRidingDistance로 조정 가능합니다.
 * 탈것에 AutoMove스크립트가 사용되어야 합니다.
 */

public class PlayerRidingVehicles : MonoBehaviour
{
    public GameObject vehicle;                  //탈것 객체
    public GameObject vehicleSkin;              //탈것 이미지
    public GameObject wall;                     //벽 객체 (이동제한을 할 벽)
    public string buttonkey = "Jump";           //탑승 버튼
    public float vaildRidingDistance = 5;       //탈 수 있는 사정거리
    public bool isRiding = false;              //탑승 여부
    // Start is called before the first frame update
    void Start()
    {
        vehicle.GetComponentInChildren<MeshRenderer>().enabled = false;           //차량 이미지 비활성화
        vehicleSkin.transform.position = vehicle.transform.position + new Vector3(0.0f, -0.583f, 0.0f);
        //탑승 여부에 따른 초기화
        if (isRiding == false)
        {
            if (vehicle.GetComponent<AutoMove>())
                vehicle.GetComponent<AutoMove>().enabled = false;                               //탈곳 객체의 이동 비활성화
            this.GetComponentInChildren<MeshRenderer>().enabled = true;
            vehicle.SetActive(false);
            vehicleSkin.SetActive(true);                                                    //차량 이미지 활성화
            wall.SetActive(true);                                                           //벽의 활성화
            wall.transform.position = vehicle.transform.position;                           //벽을 탈것 주위로 이동시킴
            isRiding = false;                                                               //탑승 off
        }
        else
        {
            if (vehicle.GetComponent<AutoMove>())
                vehicle.GetComponent<AutoMove>().enabled = true;                //탈것 객체의 이동 활성화
            this.GetComponentInChildren<MeshRenderer>().enabled = false;
            vehicleSkin.SetActive(false);                                   //차량 이미지 비활성화
            vehicleSkin.transform.position = vehicle.transform.position + new Vector3(0.0f, 1.0f, 0.0f);
            vehicleSkin.transform.rotation = Quaternion.Euler(vehicle.transform.rotation.x, vehicle.transform.rotation.y, vehicle.transform.rotation.z);
            vehicle.SetActive(true);
            wall.SetActive(false);                                          //벽의 비활성화
            isRiding = true;                                                //탑승 on
        }
    }

    private void FixedUpdate()
    {
        if (isRiding == false)      //탑승하지 않은 상태
        {
            if (Input.GetButtonDown(buttonkey) == true && Vector3.Distance(vehicle.transform.position, this.transform.position) < vaildRidingDistance)      //버튼이 눌렸고 유효거리 내에 있었을 시
            {
                if (vehicle.GetComponent<AutoMove>())
                    vehicle.GetComponent<AutoMove>().enabled = true;                //탈것 객체의 이동 활성화
                this.GetComponentInChildren<MeshRenderer>().enabled = false;
                vehicleSkin.SetActive(false);                                   //차량 이미지 비활성화
                vehicleSkin.transform.position = vehicle.transform.position + new Vector3(0.0f, 1.0f, 0.0f);
                vehicleSkin.transform.rotation = Quaternion.Euler(vehicle.transform.rotation.x, vehicle.transform.rotation.y, vehicle.transform.rotation.z);
                vehicle.SetActive(true);
                wall.SetActive(false);                                          //벽의 비활성화
                isRiding = true;                                                //탑승 on
            }
        }
        else                        //탑승한 상태
        {
            if (Input.GetButtonDown(buttonkey) == true)                     //버튼이 눌렸을 때
            {
                if (vehicle.GetComponent<AutoMove>())
                    vehicle.GetComponent<AutoMove>().enabled = false;                               //탈곳 객체의 이동 비활성화
                this.GetComponentInChildren<MeshRenderer>().enabled = true;
                this.transform.position = vehicle.transform.position + new Vector3(0, 2, vaildRidingDistance);    //탈것의 오른쪽에 내림 (오른쪽으로 탈 수 있는 거리만큼)
                this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);     //속도 초기화
                vehicle.SetActive(false);
                vehicleSkin.SetActive(true);                                                    //차량 이미지 활성화
                vehicleSkin.transform.position = vehicle.transform.position + new Vector3(0.0f, 1.0f, 0.0f);
                vehicleSkin.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);     //속도 초기화
                wall.SetActive(true);                                                           //벽의 활성화
                wall.transform.position = vehicle.transform.position;                           //벽을 탈것 주위로 이동시킴
                isRiding = false;                                                               //탑승 off
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isRiding == true)       //탑승 시
            this.transform.position = vehicle.transform.position + new Vector3(0.5f, 1.5f, 0.0f);       //플레이어가 탈것에 고정됨
        
    }
}
