using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui : MonoBehaviour {
    public Sprite R, G, B;
    public Image imgComp;
    GameObject obj;
    void Start()
    {
        obj=GameObject.FindGameObjectWithTag("Player");
        imgComp = GetComponent<Image>();
    }
	void Update () {
        int wp = obj.GetComponent<Cam>().selWeapon;
        if (wp != -1) { imgComp.enabled = true; }
        if (wp == 0) { imgComp.sprite = R; }
        else if (wp == 1) { imgComp.sprite = G; }
        else if (wp == 2) { imgComp.sprite = B; }
    }
}
