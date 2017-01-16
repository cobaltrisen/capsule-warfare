using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayVideo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MovieTexture mt = GetComponent<RawImage>().texture as MovieTexture;
        mt.loop = true;
        mt.Play();
        GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
