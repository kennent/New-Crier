using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiText : MonoBehaviour {
    public Text R, G, B;
    public GameObject PlayerData;

	void Update () {
        R.text = PlayerData.gameObject.GetComponent<Cam>().energy[0].ToString();
        G.text = PlayerData.gameObject.GetComponent<Cam>().energy[1].ToString();
        B.text = PlayerData.gameObject.GetComponent<Cam>().energy[2].ToString();
    }
}
