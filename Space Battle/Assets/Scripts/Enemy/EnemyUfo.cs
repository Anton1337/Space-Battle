using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUfo : MonoBehaviour{

    [SerializeField]
    private GameObject _bullet;

    [SerializeField]
    private GameObject _gem;

    private Rigidbody2D _rb;
    public float _speed = 11.0f;

    private bool _canShoot = true;

    public float _shotTimerMin = 3.0f;
    public float _shotTimerMax = 5.0f;

    public int _health = 42;

    private float _shotSpread = 0.25f;

    // Use this for initialization
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_canShoot)
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
            ScoreText.scoreValue += 50;
            Instantiate(_gem, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, _speed * Time.fixedDeltaTime * -1);
    }

    private void Shoot()
    {
        Instantiate(_bullet, new Vector3(transform.position.x - _shotSpread, transform.position.y - 0.23f, transform.position.z), Quaternion.identity);
        Instantiate(_bullet, new Vector3(transform.position.x, transform.position.y - 0.23f, transform.position.z), Quaternion.identity);
        Instantiate(_bullet, new Vector3(transform.position.x + _shotSpread, transform.position.y - 0.23f, transform.position.z), Quaternion.identity);
    }

    IEnumerator ResetShot()
    {
        yield return new WaitForSeconds(Random.Range(_shotTimerMin, _shotTimerMax));
        _canShoot = true;
    }
}
