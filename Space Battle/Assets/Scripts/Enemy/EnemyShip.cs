using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {

    [SerializeField]
    private GameObject _bullet;

    [SerializeField]
    private GameObject _gem;

    private Rigidbody2D _rb;
    public float _speed = 32.0f;

    private bool _canShoot = true;

    public float _shotTimerMin = 3.5f;
    public float _shotTimerMax = 5.0f;
    public int dropChance = 5;

    public int _health;

    // Use this for initialization
    void Start () {
        _rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(_canShoot)
        {
            Shoot();
            _canShoot = false;
            StartCoroutine(ResetShot());
        }
	}

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            ScoreText.scoreValue += 10;
            int dropNumber = Random.Range(0, dropChance);

            if(dropNumber == 0)
            {
                Instantiate(_gem, transform.position, transform.rotation);
            }
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, _speed * Time.fixedDeltaTime * -1);
    }

    private void Shoot()
    {
        Instantiate(_bullet, new Vector3(transform.position.x, transform.position.y - 0.23f, transform.position.z), Quaternion.identity);
    }

    IEnumerator ResetShot()
    {
        yield return new WaitForSeconds(Random.Range(_shotTimerMin, _shotTimerMax));
        _canShoot = true;
    }
}
