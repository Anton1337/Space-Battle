using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    private Rigidbody2D _rb;

    [SerializeField]
    private float _speed;
    private bool _canMove = true;

    [SerializeField]
    private Sprite _hitSprite;

    private int _damage = 1;

    private SpriteRenderer _bulletSprite;
    private bool _canDealDamage = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _bulletSprite = GetComponent<SpriteRenderer>();
        Destroy(this.gameObject, 4.0f);
    }

    private void FixedUpdate()
    {
        if(_canMove)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _speed * Time.fixedDeltaTime * -1);
        }
        else
        {
            _rb.velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && _canDealDamage)
        {
            _canDealDamage = false;
            other.GetComponent<Collider2D>().GetComponent<Player>().TakeDamage(_damage);
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
