using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameEnd : MonoBehaviour {

    public Text Score;
    public Text HighScore;
	// Use this for initialization
	void Start () {
        Score.text = "" + PlayerPrefs.GetInt("Score");
        HighScore.text = "" + PlayerPrefs.GetInt("HighScore");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("PaperPlane");
    }

    public void Achievment()
    {

    }

    public void Leaderboard()
    {

    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Share()
    {

    }
}
