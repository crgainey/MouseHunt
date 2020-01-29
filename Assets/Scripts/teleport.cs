using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public GameObject player;
    public Transform teleportTarget;

    void OnTriggerEnter2D(Collider2D other)
    {
        player.transform.position = teleportTarget.transform.position;
    }
    
}
