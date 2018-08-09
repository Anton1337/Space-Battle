using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    private GameObject _shipObject;

    [SerializeField]
    private GameObject _ufoObject;

    private Vector3 spawnPosition;

    private float _shipSpawnTimerMin = 1.5f;
    private float _shipSpawnTimerMax = 2.5f;
    private float _bossAddTime = 8.0f;
    private bool _canSpawnShip = false;

    private float _width = 2.35f;
    private float _spawnY = 5.55f;

    private int _bossChance = 100;


	// Use this for initialization
	void Start () {
        StartCoroutine(ShipSpawnReset(3.0f));
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(_canSpawnShip)
        {
            SpawnEnemy();
        }
	}

    private void SpawnEnemy()
    {
        int spawn = Random.Range(0, _bossChance);
        float xPos = Random.Range(-_width, _width);
        spawnPosition = new Vector3(xPos, _spawnY, 0);

        if (spawn == 0)
        {
            Instantiate(_ufoObject, spawnPosition, Quaternion.identity);
            _canSpawnShip = false;
            StartCoroutine(ShipSpawnReset(Random.Range(_shipSpawnTimerMin + _bossAddTime , _shipSpawnTimerMax + _bossAddTime)));
        }
        else
        {
            Instantiate(_shipObject, spawnPosition, Quaternion.identity);
            _canSpawnShip = false;
            StartCoroutine(ShipSpawnReset(Random.Range(_shipSpawnTimerMin, _shipSpawnTimerMax)));
        }
    }

    IEnumerator ShipSpawnReset(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _canSpawnShip = true;
    }

}
