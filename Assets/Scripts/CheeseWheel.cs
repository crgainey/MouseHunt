using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheeseWheel : MonoBehaviour
{
    public int scoreValue;

    GameController _gameController;
    EnemyMovement _enemy;
    EnemyAI _chaseEnemy;

    void Start()
    {
        GameObject _gameControllerObject = GameObject.FindWithTag("GameController");

        if (_gameControllerObject != null)
        {
            _gameController = _gameControllerObject.GetComponent<GameController>();
        }
        if (_gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        _enemy.GetComponent<EnemyMovement>();
        _chaseEnemy.GetComponent<EnemyAI>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            _gameController.AddScore(scoreValue);
            _enemy.Runaway();
            _chaseEnemy.Runaway();
        }
    }
}
