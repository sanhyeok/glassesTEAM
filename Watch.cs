using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Watch : MonoBehaviour
{
    public Text txtsec;    //경과 시간(초단위)을 출력할 text

    public Text txt;       //경과 시간(분단위)을 출력할 text

    public int i = 0;             //실질적 경과시간(분)

    bool activated=false;     //시간을 셀지 안셀지 판별하는 bool

    public float timeElapsed=0;//실질적 경과시간(초)
    // Start is called before the first frame update
    void Start()
    {
        activated = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(activated)
        {
            timeElapsed += UnityEngine.Time.deltaTime; //업데이트마다 기존시간에 경과한시간만큼 더함
            if (timeElapsed > 59.6)
            {
                timeElapsed = 0;
                i++;
            }

            txt.text = i.ToString();
            txtsec.text = timeElapsed.ToString("0");    //업데이트된 시간을 출력
        }
    }

    public void printtime()     //끝나고 출력할때 불러올 함수
    {

    }
    public void menutime()
    {
        activated = !activated;
    }
    public void StartWatch()
    {
        activated = !activated;  //시간경과를 일시정지 시키거나 다시시작하는 함수
        timeElapsed = 0;
        i = 0;
    }
}
