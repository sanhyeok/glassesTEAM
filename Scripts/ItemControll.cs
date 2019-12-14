using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControll : MonoBehaviour
{
    public GameObject Character;
    public GameObject Camera;
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
                this.transform.position += new Vector3(0, 2, 1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsUsed == true)
        {
            this.transform.rotation = Character.transform.rotation;
            this.transform.position = Character.transform.position + new Vector3(Camera.transform.rotation.eulerAngles.normalized.x*2, Camera.transform.rotation.eulerAngles.normalized.y * 2, Camera.transform.rotation.eulerAngles.normalized.z * 2);
        }
    }
}
