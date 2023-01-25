using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class God : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Player _player;

    private int _maxRestoredHealth = 20;
    private float _positionY = 5f;
    private float _positionX = 8f;

    public Player Target => _player;

    public void Attack()
    {
        Instantiate(_bullet, CreateRandomPosition(), Quaternion.identity);
    }

    public void RestoreHealth()
    {
        _player.Heal(Random.Range(0, _maxRestoredHealth));
    }

    private Vector2 CreateRandomPosition()
    {
        Vector2 randomPosition = new Vector2(Random.Range(-_positionX, _positionX), _positionY);

        return randomPosition;
    }
}
