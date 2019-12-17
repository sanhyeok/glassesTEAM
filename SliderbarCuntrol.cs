using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderbarCuntrol : MonoBehaviour
{
    private GameObject start;  //위치정보를 가지고 있는 리스트 선언.
    private GameObject Dest;
    private GameObject Player;
    public Text dalsungdo;
    [SerializeField] private Slider slider;
    float a;
    // Start is called before the first frame update

    void Start()
    {
        Dest = GameObject.Find("Dest");
        start = GameObject.Find("Start");
        Player = GameObject.Find("Player");


        slider.minValue = start.transform.position.x + start.transform.position.y + start.transform.position.z;
        slider.maxValue = Dest.transform.position.x + Dest.transform.position.y + Dest.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Player.transform.position.x + Player.transform.position.y + Player.transform.position.z;
        a = (slider.value / slider.maxValue);
        dalsungdo.text = a.ToString("0.0"+"%");
    }
}
