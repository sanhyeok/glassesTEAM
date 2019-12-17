using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeScript : MonoBehaviour
{
    public Image Panel;  // 투명화시켜놓은 검은 이미지
    float time = 0f;     //초기시간
    float F_time = 1f;   //최대시간
    public void Fadein()  //페이드아웃 함수
    {
        StartCoroutine(FadeIn());
    }
    public void Fadeout()
    {
        StartCoroutine(FadeOut());
    }
    public void Fadeinout()
    {
        StartCoroutine(FadeInOut());
    }

    IEnumerator FadeInOut()
    {
        time = 0f;
        Color alpha = Panel.color;
        Panel.gameObject.SetActive(true); 
        while (alpha.a < 1f)           
        {
            time += Time.deltaTime / F_time; 
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        time = 0f;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        yield return null;
    }
    IEnumerator FadeOut()
    {
        time = 0f;
        Color alpha = Panel.color;
        while (alpha.a > 0f)           
        {
            time += Time.deltaTime / F_time; 
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        yield return null;
    }

    IEnumerator FadeIn()
    {
        time = 0f;
        Panel.gameObject.SetActive(true); //패널 활성화
        Color alpha = Panel.color;
        while(alpha.a<1f)           //패널의 alpha값이 풀이될때까지 점점 밝아지게하는 반복문   
        {
            time += Time.deltaTime / F_time;  //시간이 경과함에 따라 패널의 검은이미지의 알파값이 증가하며 점점밝아짐
            alpha.a = Mathf.Lerp(0,1,time);
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
    }
}
