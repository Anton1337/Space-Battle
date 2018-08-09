using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgrondSnapper : MonoBehaviour {

    private float _speed = 2.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, -1 * _speed * Time.deltaTime, 0));

        if(transform.position.y <= -14)
        {
            Vector3 snapPos = new Vector3(transform.position.x, 16, transform.position.z);
            transform.position = snapPos;
        }
	}
}
