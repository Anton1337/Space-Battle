using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private Rigidbody2D _rb;
    private SpriteRenderer _playerSprite;
    [SerializeField]
    private float _speed;
    private float _direction;

    private Camera _cam;

    public GameObject endScreen;

    [SerializeField]
    private Sprite _playerLeft;
    [SerializeField]
    private Sprite _playerRight;
    [SerializeField]
    private Sprite _playerStill;

    private float maxWidth = 2.35f;
    private float minWidth = -2.35f;

    public int health = 3;
    private bool _canShoot = true;
    private float _shotTimer = 0.18f;

    [SerializeField]
    private GameObject _bullet;

    void Start () {
        _rb = GetComponent<Rigidbody2D>();
        _playerSprite = GetComponent<SpriteRenderer>();
        _cam = Camera.main;
        endScreen.SetActive(false);
        Time.timeScale = 1;
    }
	
	void Update () {
        // Check move input.
        //_direction = Input.GetAxisRaw("Horizontal");

        //PickSprite(_direction);

        if(_canShoot)
        {
            Shoot();
            _canShoot = false;
            StartCoroutine(ShotReset());
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("EnemyShip") || other.CompareTag("EnemyUfo"))
        {
            TakeDamage(health);
        }
    }

    private void PickSprite(float direction)
    {
        if(_direction > 0.1)
        {
            _playerSprite.sprite = _playerRight;
        }
        else if(_direction < -0.1)
        {
            _playerSprite.sprite = _playerLeft;
        }
        else
        {
            _playerSprite.sprite = _playerStill;
        }
    }

    private void Shoot()
    {
        Instantiate(_bullet, new Vector3(transform.position.x, transform.position.y + 0.23f, transform.position.z), Quaternion.identity);
    }

    IEnumerator ShotReset()
    {
        yield return new WaitForSeconds(_shotTimer);
        _canShoot = true;
    }

    private void FixedUpdate()
    {
        Movement(_direction);
    }

    private void Movement(float direction)
    {
        /* if ((transform.position.x >= maxWidth && direction > 0) || (transform.position.x <= minWidth && direction < 0))
         {
             _rb.velocity = new Vector2(0, _rb.velocity.y);
         }
         else
         {
             _rb.velocity = new Vector2(direction * _speed, _rb.velocity.y);
         }
         */
         if(Input.touches.Length != 0)
        {
            _rb.position = _cam.ScreenToWorldPoint(Input.touches[0].position);
        }
        //_rb.position = _cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            if(ScoreText.scoreValue > ZPlayerPrefs.GetInt("Highscore"))
            {
                ZPlayerPrefs.SetInt("Highscore", ScoreText.scoreValue);
            }
            Time.timeScale = 0;
            endScreen.SetActive(true);
            
        }
    }

    public void GetDiamonds(int amountOfDiamonds)
    {
        GameManager.AddDiamonds(amountOfDiamonds);
    }
}
