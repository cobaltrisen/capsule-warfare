using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonController : MonoBehaviour {
    public float buttonState;
    Button[] b;
	// Use this for initialization
	void Start () {
        b = GetComponentsInChildren<Button>();
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Button bu in b) {
            if (buttonState == 1.0f) {
                bu.interactable = true;
            } else {
                bu.interactable = false;
            }
        }
	}
}
