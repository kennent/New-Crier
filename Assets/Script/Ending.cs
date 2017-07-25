using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public Image Scene1;
    public Image Scene2;
    public Image Scene3;
    public Image Scene4;

    void Start()
    {
        StartCoroutine(Scene());
    }

    IEnumerator Scene()
    {
        for(float i = 255;i >= 0; i-=1.5f)
        {
            Scene1.color = new Color(Scene1.color.r, Scene1.color.g, Scene1.color.b, i / 255f);
            yield return null;
        }
        for (float i = 255; i >= 0; i --)
        {
            Scene2.color = new Color(Scene2.color.r, Scene2.color.g, Scene2.color.b, i/255f);
            yield return null;
        }
        for(float i = 255; i >= 0; i--)
        {
            Scene3.color = new Color(Scene3.color.r, Scene3.color.g, Scene3.color.b, i / 255f);
            yield return null;
        }
        for (float i = 255; i >= 0; i -= 1.5f)
        {
            Scene4.color = new Color(Scene4.color.r, Scene4.color.g, Scene4.color.b, i / 255f);
            yield return null;
        }
    }
}
