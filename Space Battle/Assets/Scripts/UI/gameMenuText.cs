﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMenuText : MonoBehaviour {

    public Text gemText;
    // Use this for initialization
    void Start()
    {
        gemText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        gemText.text = MainMenuManager.diamondCount.ToString();
    }
}
