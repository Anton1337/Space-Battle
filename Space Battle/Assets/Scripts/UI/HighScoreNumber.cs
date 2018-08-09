using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreNumber : MonoBehaviour {

    public Text highscoreText;

	// Use this for initialization
	void Start () {
        highscoreText.text = ZPlayerPrefs.GetInt("Highscore", 0).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
