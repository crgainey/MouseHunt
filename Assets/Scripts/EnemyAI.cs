using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using Pathfinding;

//Using A* Project pathfinding
public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public float speed;
    public float NextWaypointDistance;
    public float radius;

    public int scoreValue;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    public Animator anim;

    public int currentState;

    GameController _gameController;

    public float startTime = 0;
    public float startTimeDelay = 2;

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

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        InvokeRepeating("UpdatePath", 0f, .5f);

        Physics2D.IgnoreLayerCollision(8, 9);
    }

    private void FixedUpdate()
    {

        switch (currentState)
        {
            case 0:
                Chase();
                break;

            case 1:
                Runaway();
                break;
        }
    }

    Vector2 StartPoint()
    {
        return new Vector2(-0.94f, 1.25f);
    }
    public void UpdatePath()
    {

        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }

    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    // Update is called once per frame

    void Chase()
    {
        startTime += Time.deltaTime;

        if (startTime >= startTimeDelay)
        {
            if (path == null)
            {
                return;
            }

            if (currentWaypoint >= path.vectorPath.Count)
            {
                reachedEndOfPath = true;
            }
            else
            {
                reachedEndOfPath = false;
            }

            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < NextWaypointDistance)
            {
                currentWaypoint++;
            }
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
            if (currentState == 1)
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