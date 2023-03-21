using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "MenuScene")
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
    public void GoToGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
