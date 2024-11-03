using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    // holds all the stuff game related
    
    //REFERENCES
    public Image progressBar;     //reference to the progress bar
    public GameObject player;
    private collide npcCollide;


    // DECLARATION VARIABLES
    public Text timerText;
    public GameObject gameEnd;
    private float currentTime;
    private float progress;
    private bool isHoldingButton = false;

    // VALUES VARIABLES
    public float timeDuration = 60f;
    private float initialValue = 0f;
    public float progressSpeed = 1f;
    public float decreaseAmount= 3f;




    void Start() {
        progress = 0f;
        progressBar.fillAmount = initialValue; //set the progress to be 0
        TimeCounter();
        npcCollide = GameObject.Find("NPC").GetComponent<collide>();
    }

    void TimeCounter() {
        // currentTime = Time.time; //gives the current time after the game started
        currentTime = timeDuration; //sets the starting time to the limit
        Debug.Log(currentTime);
    }

    void FixedUpdate() {
        // TimeCounter();
        if (currentTime > 0) {
            currentTime -= Time.deltaTime;
            timerText.text = Mathf.Ceil(currentTime).ToString() + "s";
        } else {
            GameOver();
        }

        if (npcCollide.GetIsNearCollider() && Input.GetKey(KeyCode.Space)) {
            isHoldingButton = true;
        } else {
            isHoldingButton = false;
        }

        if (isHoldingButton) {
            progress -= decreaseAmount * Time.deltaTime / timeDuration;
            progress = Mathf.Clamp(progress, 0f, 1f);
        } else {
            progress += progressSpeed * Time.deltaTime / timeDuration;
            progress = Mathf.Clamp(progress, 0f, 1f);
        }

        progressBar.fillAmount = progress;

        if (progress >= 1f) {
            ProjectOver();
        }
    }

    void ProjectOver() {
        gameEnd.SetActive(true);
        Debug.Log("project over");
    }

    void GameOver() {
        Debug.Log("game over");
        player.GetComponent<Move>().enabled = false; 
        //stop the player from moving
        gameEnd.SetActive(true);

    }

}
