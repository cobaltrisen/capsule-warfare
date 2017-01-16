using UnityEngine;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour {
    public GameObject[] frames = { };
    public string currentFrame;
    void Start() {
        currentFrame = "Main";
    }
    public void GoToFrame(string frame) {
        GetComponent<AudioSource>().Play();
        GameObject.Find(currentFrame).GetComponent<Animator>().SetTrigger("out");
        foreach (GameObject g2 in frames) {
            if (g2.name == frame) {
                g2.GetComponent<Animator>().SetTrigger("in");
                currentFrame = g2.name;
            }
        }
    }
    public void Exit() {
        Application.Quit();
    }
}
