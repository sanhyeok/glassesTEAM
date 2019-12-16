using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControll : MonoBehaviour
{
    public GameObject Character;
    public float InteractiveDistance = 5;
    public string buttonkey = "Jump";           //아이템 장착 버튼
    private bool IsUsed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (IsUsed == false)
        {
            if (Input.GetButtonDown(buttonkey) == true && Vector3.Distance(Character.transform.position, this.transform.position) < InteractiveDistance)
            {
                IsUsed = true;
            }
        }
        else
        {
            if (Input.GetButtonDown(buttonkey) == true)
            {
                IsUsed = false;
                this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);     //속도 초기화
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsUsed == true)
        {
            this.transform.position = Character.transform.position;
            this.transform.rotation = Character.transform.rotation;
        }
    }
}
