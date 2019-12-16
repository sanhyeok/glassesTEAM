using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderbarCuntrol : MonoBehaviour
{
    public List<Transform> waypoint = new List<Transform>();  //위치정보를 가지고 있는 리스트 선언.
    [SerializeField] private Slider slider;
    // Start is called before the first frame update

    void Start()
    {
        slider.minValue = waypoint[0].position.x + waypoint[0].position.z+ waypoint[0].position.y;
        slider.maxValue= waypoint[1].position.x + waypoint[1].position.z+ waypoint[1].position.y;
        slider.value= waypoint[2].position.x + waypoint[2].position.z+ waypoint[2].position.y;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = waypoint[2].position.x + waypoint[2].position.z+ waypoint[2].position.y;
    }
}
