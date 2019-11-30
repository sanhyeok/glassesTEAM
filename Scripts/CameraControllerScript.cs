using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 제작 : 신동규
 * 카메라를 움직이고 원하는 객체에 고정하는 코드입니다.
 */

public class CameraControllerScript : MonoBehaviour
{
    Vector2 mouse_position;
    Vector2 chged_position;

    Vector3 offset;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        mouse_position = Vector2.zero;
        chged_position = Vector2.zero;
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

    void Update()
    {

        chged_position = mouse_position - (Vector2)Input.mousePosition;
        if (((transform.eulerAngles.x + chged_position.y) >= -90 && transform.eulerAngles.x + chged_position.y <= 90) ||
            (transform.eulerAngles.x + chged_position.y >= 270 && transform.eulerAngles.x + chged_position.y <= 450))
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x + chged_position.y, transform.eulerAngles.y - chged_position.x, 0f);
        }
        mouse_position = Input.mousePosition;

        
    }
}
