using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public int lives;
    public int score;
    public Text life;
    public Text scores;
    public bool gameOver;
    public GameObject gameOverPanel;
    public int numberOfBricks;
    public Transform[] levels;
    public int currentLevelIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        life.text = "Lives : " + lives;
        scores.text = "Score : " + score;

        numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int changeInLives)
    {

        lives += changeInLives;

        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        life.text = "Lives : " + lives;
    }
    public void UpdateScore(int points)
    {
        score += points;
        scores.text = "Score : " + score;
    }

    public void UpdateNumberOfBricks()
    {
        
            numberOfBricks--;
            if (numberOfBricks == 0)
            {
            if (currentLevelIndex >= levels.Length - 1)
            {
                GameOver();
            }
            else
            {
                //    gameOver = true;
                //    //Invoke("loadlevel()",3f);

                SceneManager.LoadScene("level 2");
                currentLevelIndex++;
                }


            }
       
        
    }
    //void loadlevel()
    //{
    //    currentLevelIndex++;
    //    Instantiate(levels[currentLevelIndex], Vector2.zero, Quaternion.identity);
    //    numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length;
    //    gameOver = false;
    //}

    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("game exit");
    }
}
