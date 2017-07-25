using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Image Scene1;

    void Start()
    {
        StartCoroutine(Scene());
    }

    IEnumerator Scene()
    {
        for (float i = 255; i >= 0; i -= 3.5f)
        {
            Scene1.color = new Color(Scene1.color.r, Scene1.color.g, Scene1.color.b, i / 255f);
            yield return null;
        }
    }
}
