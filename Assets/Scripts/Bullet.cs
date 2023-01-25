using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed = 20f;

    private int _minDamage = 1;
    private int _maxDamage = 30;

    private void Start()
    {
        _player = FindObjectOfType<Player>().GetComponent<Player>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.TakeDamage(ReturnRandomDamage());

            Destroy(this.gameObject);
        }
    }

    private int ReturnRandomDamage()
    {
        return Random.Range(_minDamage, _maxDamage);
    }
}
