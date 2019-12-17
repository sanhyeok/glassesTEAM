using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    public Image image;
    public Text text1;
    public Text text2;
    public Text sec;
    public Text min;
    public Text colon;
    public Text dalsungdo;
    public Button button1;
    public Button button2;
    public Button button3;

    public void Start()
    {
        sec.gameObject.SetActive(false);
        min.gameObject.SetActive(false);
        colon.gameObject.SetActive(false);
        dalsungdo.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button3.gameObject.SetActive(false);
    }
    public void callmenu()
    {
        dalsungdo.gameObject.SetActive(true);
        image.gameObject.SetActive(true);
        sec.gameObject.SetActive(true);
        min.gameObject.SetActive(true);
        colon.gameObject.SetActive(true);
        text1.gameObject.SetActive(true);
        text2.gameObject.SetActive(true);
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);
        button3.gameObject.SetActive(true);

    }
    public void backmenu()
    {
        dalsungdo.gameObject.SetActive(false);
        sec.gameObject.SetActive(false);
        min.gameObject.SetActive(false);
        colon.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button3.gameObject.SetActive(false);

    }
}
