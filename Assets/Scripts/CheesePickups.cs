using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheesePickups : MonoBehaviour
{

    public int scoreValue;

    GameController _gameController;

    void Start()
    {
        _gameController.GetComponent<GameController>();
    }

        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            _gameController.AddScore(scoreValue);
        }
    }
}
