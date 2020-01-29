using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyMovement : MonoBehaviour
{
    public GameObject calicoEnemy;
    public GameObject orangeEnemy;
    public GameObject grayEnemy;
    
    public float speed;
   
    public Transform[] waypoints;
    public int currentWaypoint = 0;

    Rigidbody2D rb;

    GameController _gameController;

    public Animator anim;

    public int currentState;

    public float startTime = 0;
    public float startTimeDelay = 2;
    public int scoreValue;

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

        //sets the name of the enemys
      
        calicoEnemy.name = "Calico";
        orangeEnemy.name = "Orange";
        grayEnemy.name = "Gray";
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        currentState = 0;

        Physics2D.IgnoreLayerCollision(8, 9);
    }

    private void FixedUpdate()
    { 

        switch (currentState)
        {
            case 0:
                Scatter();
                break;

            case 1:
                Runaway();
                break;
        }
    }
 

    //The position in the box
    Vector2 StartPoint()
    {
        switch (gameObject.name)
        {
           
            case "Calico":
                return new Vector2(-0.15f, 1.23f);

            case "Orange":
                return new Vector2(1.02f, 1.27f);

            case "Gray":
                return new Vector2(2.03f, 1.15f);
        }
        return new Vector2();
    }

    //the start area the ghosts go to
    void Scatter()
    {
        startTime += Time.deltaTime;

        if (startTime >= startTimeDelay)
        {
            if (transform.position != waypoints[currentWaypoint].position)
            {
                Vector2 pos = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
                GetComponent<Rigidbody2D>().MovePosition(pos);
            }

            else currentWaypoint = (currentWaypoint + 1) % waypoints.Length;

        }
    }

    public void Runaway()
    {
        if (currentState == 1)
        {
            anim.SetBool("runaway", true);
            transform.position = StartPoint();
            //set animation to vun
        }

        else currentState = 0;
        anim.SetBool("runaway", false);

    }

   private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.CompareTag("Player"))
        {

            Debug.Log("Collided with player");
            if(currentState == 1)
            {
                _gameController.AddScore(scoreValue);
            }

            else
            {
                _gameController.UpdateLives();
            }
        }
    }
}
