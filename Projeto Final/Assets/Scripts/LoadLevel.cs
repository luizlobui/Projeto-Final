using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void LoadScene(string name) // carrega a cena
    {

        SceneManager.LoadScene(name);
    }

    public void QuitGame() // fecha o game
    {
        Application.Quit();
    }

}
