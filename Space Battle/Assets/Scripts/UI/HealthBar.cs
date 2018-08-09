using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Player player;

    public GameObject[] healthBar;

    int healthbBarUnits;

	void Start () {
        healthbBarUnits = player.health;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateHealth();
	}

    public void UpdateHealth()
    {
        for (int i = 0; i < healthbBarUnits; i++ )
        {
            if(i < player.health)
            {
                healthBar[i].SetActive(true);
            }
            else
            {
                healthBar[i].SetActive(false);
            }
        }
    }
}
