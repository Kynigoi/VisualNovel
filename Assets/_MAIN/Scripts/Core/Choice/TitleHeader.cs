using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleHeader : MonoBehaviour
{

    public Image banner;
    public TextMeshProUGUI titleText;
    public string title {get{return titleText.text;} set{titleText.text = value;}} 

    public enum DISPLAY_METHOD
    {
        instant,
        slowFade,
        typeWriter
    }
    public DISPLAY_METHOD display_method = DISPLAY_METHOD.instant;
    public float fadeSpeed = 1;

   public void Show(string displayTitle)
   {
        title = displayTitle;
        if(isRevealing)
            StopCoroutine(Revealing());
        
        revealing = StartCoroutine(Revealing());
   }

   public void Hide()
   {
        if(isRevealing)
            StopCoroutine(Revealing());
        revealing = null;

        banner.enabled = false;
        titleText.enabled = false;
   }

    public bool isRevealing {get{return revealing != null;}}
   Coroutine revealing = null;

   IEnumerator Revealing()
   {
        banner.enabled = true;
        titleText.enabled = true;

        switch(display_method)
        {
            case DISPLAY_METHOD.instant:
                banner.color = SetAlpha(banner.color, 1);
                titleText.color = SetAlpha(titleText.color, 1);
                break;
            case DISPLAY_METHOD.slowFade:
                banner.color = SetAlpha(banner.color, 0);
                titleText.color = SetAlpha(titleText.color, 0);
                while(banner.color.a < 1)
                {
                    banner.color = SetAlpha(banner.color, Mathf.MoveTowards(banner.color.a, 1, fadeSpeed * Time.unscaledDeltaTime));
                    titleText.color = SetAlpha(titleText.color, banner.color.a);
                    yield return new WaitForEndOfFrame();
                }
                break;
            case DISPLAY_METHOD.typeWriter:
                banner.color = SetAlpha(banner.color, 1);
                titleText.color = SetAlpha(titleText.color, 1);
                TextArchitect architect = new TextArchitect(titleText);
                while(architect.isBuilding)
                    yield return new WaitForEndOfFrame();
                break;
        }

        //title is displayed now
        revealing = null;
   }

   public static Color SetAlpha(Color color, float alpha)
   {
        return new Color(color.r, color.g, color.b, alpha);
   }

}
