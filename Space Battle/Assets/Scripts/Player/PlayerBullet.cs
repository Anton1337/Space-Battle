using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    private Rigidbody2D _rb;

    [SerializeField]
    private float _speed;
    private bool _canMove = true;

    [SerializeField]
    private Sprite _hitSprite;

    private int _damage = 1;

    private SpriteRenderer _bulletSprite;

    private float _topOfScreen = 5.0f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _bulletSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(transform.position.y >= _topOfScreen)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if(_canMove)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _speed * Time.fixedDeltaTime);
        }
        else
        {
            _rb.velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "EnemyShip")
        {
            _canMove = false;
            _bulletSprite.sprite = _hitSprite;
            other.GetComponent<Collider2D>().GetComponent<EnemyShip>().TakeDamage(_damage);
            StartCoroutine(Destroy());
        }
        else if (other.tag == "EnemyUfo")
        {
            _canMove = false;
            other.GetComponent<Collider2D>().GetComponent<EnemyUfo>().TakeDamage(_damage);
            _bulletSprite.sprite = _hitSprite;
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.03f);
        Destroy(this.gameObject);
    }
}
