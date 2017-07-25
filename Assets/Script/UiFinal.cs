using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiFinal : MonoBehaviour {
    Canvas can;
    public GameObject Play;
    public Text A, B, C;
    int a, b, c;

    private void Start()
    {
        a = 0;
        b = 0;
        c = 0;
        can = GetComponent<Canvas>();
    }
	public void FocusOn()
    {
        Cursor.lockState = 0;
        Cursor.visible = true;
        gameObject.active = true;
    }
    public void FocusOff()
    {
        gameObject.active = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void C1()
    {
        a += 1;
        if (a > Play.GetComponent<Cam>().energy[0])
        {
            a = Play.GetComponent<Cam>().energy[0];
        }
    }
    public void C2()
    {
        a -= 1;
        if (a < 0)
        {
            a = 0;
        }
    }
    public void C3()
    {
        b += 1;
        if (b > Play.GetComponent<Cam>().energy[1])
        {
            b = Play.GetComponent<Cam>().energy[1];
        }
    }
    public void C4()
    {
        b -= 1;
        if (b < 0)
        {
            b = 0;
        }
    }
    public void C5()
    {
        c += 1;
        if (c > Play.GetComponent<Cam>().energy[2])
        {
            c = Play.GetComponent<Cam>().energy[2];
        }
    }
    public void C6()
    {
        c -= 1;
        if (c < 0)
        {
            c = 0;
        }
    }
    public void C7()
    {
        Play.GetComponent<Cam>().MakeWeapon(a,b,c);
    }
    private void Update()
    {
        A.text = a.ToString();
        B.text = b.ToString();
        C.text = c.ToString();
    }
}
