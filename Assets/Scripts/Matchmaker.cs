using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using System.Collections;
using System.Collections.Generic;
using System;

public class Matchmaker : MonoBehaviour {
    NetworkManager nManager;
    NetworkMatch mm;
    public GameObject matchTemplate;
    void Start() {
        nManager = GetComponent<NetworkManager>();
        nManager.StartMatchMaker();
        mm = nManager.matchMaker;
        FindInternetMatches();
    }
    public void CreateInternetMatch(String name) {
        mm.CreateMatch(name, (uint)4, true, "", "", "", 0, 0, nManager.OnMatchCreate);
    }

    public void FindInternetMatches() {
        foreach (Transform g in GameObject.Find("ServerList").transform) {
            if (g.gameObject.activeInHierarchy == true) {
                Destroy(g.gameObject);
            }
        }
        mm.ListMatches(0, 10, "", true, 0, 0, OnMatchList);
    }

    void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches) {
        Debug.Log("list");
        print(matches.Count+" matches found");
        foreach (MatchInfoSnapshot mis in matches) {
            GameObject template = (GameObject)Instantiate(matchTemplate);
            template.GetComponent<ServerInfo>().match = mis;
            template.transform.SetParent(GameObject.Find("ServerList").transform, false);
            template.name = mis.name;
            template.SetActive(true);
        }
    }
    public void JoinMatch (MatchInfoSnapshot mis){
            mm.JoinMatch(mis.networkId, "", "", "", 0, 0, nManager.OnMatchJoined);
    }
}
