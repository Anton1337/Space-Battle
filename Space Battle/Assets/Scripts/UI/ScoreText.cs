using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    public static int scoreValue = 0;

    private Text _score;

	void Start () {
        scoreValue = 0;
        _score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        _score.text = scoreValue.ToString();
		
	}
}
