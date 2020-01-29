using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pacman : MonoBehaviour
{
    public float speed = 4.0f;
    
    private int lives = 3;
    private int pickupAmount;
    private Vector2 direction = Vector2.zero;
    public int score = 0;


    GameController gm;




    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponent<GameController>();




    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Specifically for physics updates
    void FixedUpdate()
    {
        UpdateOrientation();
        CheckInput();
        Move();
    }


    void CheckInput()
    {

        //gets input from user to move object
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }
    }


    //takes local position and adds/subtracts from it based on which key the user presses from CheckInput method
    void Move()
    {
        transform.localPosition += (Vector3)(direction * speed) * Time.deltaTime;

    }

    void UpdateOrientation()
    {
        //transforms local scale of x to the opposite direction facing left
        if (direction == Vector2.left)
        {
            transform.localScale = new Vector3(3, 2, 1);
            //makes sure to rotate pacman back to default direction after looking up or down
            transform.localRotation = Quaternion.Euler(0, 0, 0);

            //takes local scale of x and faces to the right
        }
        else if (direction == Vector2.right)
        {
            transform.localScale = new Vector3(-3, 2, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 0);

            
        }
        else if (direction == Vector2.up)
        {
            transform.localScale = new Vector3(3, 2, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 270);
        }
        else if (direction == Vector2.down)
        {
            transform.localScale = new Vector3(3, 2, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 90);


        }
        
    }

    void ResetPlayer()
    {
        new Vector2(1.114f, 1.622f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       

        if(other.gameObject.CompareTag("cheeseSlice"))//regular pickups on the 
        {
            other.gameObject.SetActive(false);
            score = score + 10;

            if (score >= 1260)
            {
                SceneManager.LoadScene("Level2");
            }

        }
        else if (other.gameObject.CompareTag("cheeseWheel"))//powerup to kill enemies
        {
            other.gameObject.SetActive(false);

            //score = score + 50;

        }

        //should reset playerTransform
        if (other.gameObject.CompareTag("Enemy"))
        {
            ResetPlayer();
        }

    }
}
