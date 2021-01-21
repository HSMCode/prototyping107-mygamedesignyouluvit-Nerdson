using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int speed;
    private int score;                   //players score
    public int lives;                   //this is the number of lives the player has
    public Text livesText;              //link to the LivesText on  the screen
    public Text scoreText;              //link to the ScoreText on the screen
    public GameObject gameOverPanel;    //link to the gameOverPanel in the scene
    public GameObject WINPanel;         //link to the WINPanel in the scene
    public ParticleSystem hearts;       //link to the ParticleSystem in the scene
    public AudioSource micCheckOneTwo;  

    private void Start()
    {
        speed = 10;
        score = 0;
        lives = 5;
        livesText.text = "Lives: " + lives.ToString();
        scoreText.text = "Score: " + score.ToString();

        //turn off gameOverPanel and WINPanel
        gameOverPanel.SetActive(false);
        WINPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed);

        //Check to see if the player has left the left edge of the screen
        if (transform.position.x < -8.25f)
        {
            //Move the player back to the edge of the screen
            transform.position = new Vector3(-8.25f, transform.position.y);
        }

        //Check to see if the player has left the right edge of the screen
        if (transform.position.x > 8.25f)
        {
            //Move the player back to the edge of the screen
            transform.position = new Vector3(8.25f, transform.position.y);
        }
    }

    // ScorePoints will be called from the FallingGoldScript when a collision occures between the player and the gold object
    public void ScorePointsGold()
    {
        //add points to the score
        score += 1;
        //update the score text on the screen
        scoreText.text = "Score: " + score.ToString();
    }

    // ScorePoints will be called from the FallingGoldScript when a collision occures between the player and the gold object
    public void ScorePointsStar()
    {
        //add points to the score
        score += 3;
        //update the score text on the screen
        scoreText.text = "Score: " + score.ToString();
    }

    // ScorePoints will be called from the FallingCoalScript when a collision occures between the player and the coal object
    public void ScorePointsCoal()
    {
        //subtract points to the score
        score -= 1;
        //update the score text on the screen
        scoreText.text = "Score: " + score.ToString();

        if (score > 100)
        {
            WIN();
            score = 101;
        }
    }

    // LoseLife will be called from the FallingCoalScript when a collision occures between the player and the coal object
    public void LoseLife()
    {
        lives--;    //subtract 1 from lives

        //check to see if out of lives
        if (lives < 1)
        {
            //out of lives
            GameOver();
            lives = 0;
        }

        //update the lives text on the screen
        livesText.text = "Lives: " + lives.ToString();
    }

    public void LifeUp()
    {
        //instatiate the particles when LifeUp is collected
        hearts.Play();
        lives += 1;
        //update the lives text on the screen
        livesText.text = "Lives: " + lives.ToString();
    }

    public void MicCheck()
    {
        //play the mic check sound
        micCheckOneTwo.Play();
    }

void WIN()
    {
        //Make player disappear and be disabled
        gameObject.SetActive(false);

        //turn on WINPAnel
        WINPanel.SetActive(true);
    
    }

    void GameOver()
    {
        //Make player disappear and be disabled
        gameObject.SetActive(false);

        //turn on gameOverPanel
        gameOverPanel.SetActive(true);
    }


    //playAgainButton from the gameOverPanel
    public void PlayAgain()
    {
        //restart the game
        SceneManager.LoadScene("SampleScene");
    }

    //quitButton from the GameOverPanel
    public void Quit()
    {
        //close the window where the game is being played in 
        Application.Quit();
    }

    

}
