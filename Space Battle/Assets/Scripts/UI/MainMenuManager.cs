using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour {

    public static int diamondCount;

    public static int highscore;

	// Use this for initialization
	void Start () {
        ZPlayerPrefs.Initialize("agoodpassword", "whatisthislol");
        diamondCount = ZPlayerPrefs.GetInt("Diamonds", 0);
        highscore = ZPlayerPrefs.GetInt("Highscore", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
