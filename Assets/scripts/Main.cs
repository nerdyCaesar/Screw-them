using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{

    public void Play () {
        SceneManager.LoadScene(1);
    }

    public void Quit () {
        Debug.Log("Application is closing...");
        Application.Quit();
    }
}
