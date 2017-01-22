using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking.Match;
public class ServerInfo : MonoBehaviour {
    public MatchInfoSnapshot match;
    public string name;
    public int players;
    public int playerCap;
    bool joined;
	// Use this for initialization
	void Start () {
        joined = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (match != null) {
            name = match.name;
            players = match.currentSize;
            playerCap = match.maxSize;
            transform.Find("Name").GetComponent<Text>().text = name;
            transform.Find("Players").GetComponent<Text>().text = players+"/"+playerCap+"    ";
            GetComponent<Button>().onClick.AddListener(Join);
        }
	}
    void Join() {
        if (joined == false) {
            GameObject.Find("NetworkManager").GetComponent<Matchmaker>().JoinMatch(match);
            joined = true;
        }
    }
}
