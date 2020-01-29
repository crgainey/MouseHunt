using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour

{
    public Button startGameButton;
    public GameObject self;

    public void Begin()
    {
        //SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
        //self.SetActive(false);
        SceneManager.LoadScene("Level1");

    }
}
