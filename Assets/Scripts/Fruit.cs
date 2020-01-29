using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public float startTime = 0;
    public float startTimeDelay = 15;

    public int scoreValue;

    public GameObject banana;
    //public GameObject otherfruit;

    GameController _gameController;

    // Start is called before the first frame update
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

        startTime += Time.deltaTime;
        banana.SetActive(false);
        //otherfruit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime >= startTimeDelay)
        {
            banana.SetActive(true);
            //otherfruit.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _gameController.AddScore(scoreValue);
        }
    }
}
