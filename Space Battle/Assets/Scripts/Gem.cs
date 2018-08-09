using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {

    private float speed = 6.0f;

    private int value = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       Move();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Player>().GetDiamonds(value);
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.Translate(0, speed * Time.deltaTime * -1, 0);
    }
}
