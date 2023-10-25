using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

    public Vector2 position1,position2;
    public GameObject coin1,coin2;
    public float circle;
    public Text SCORE;
    public static bool gameOver = false;
    public static bool gameStart = false;
    public GameObject Init;
    public int lastCoinPos;
    int choice1,choice2;
    public AudioSource audioSource;
    public AudioClip[] audioClip;
    // Use this for initialization
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        circle = 2.13f;
        choice1 = Random.Range(5, 18);
        choice2 = Random.Range(5, 18);
        //lastCoinPos = choice;
        while(choice1 == choice2)
        {
            choice2 = Random.Range(5, 18);
        }
        position1 = new Vector2(Mathf.Sin(choice1 / Mathf.PI) * circle, Mathf.Cos(choice1 / Mathf.PI) * circle);
        GameObject c1 = Instantiate(coin1, position1, Quaternion.identity);

        position2 = new Vector2(Mathf.Sin(choice2 / Mathf.PI) * circle, Mathf.Cos(choice2 / Mathf.PI) * circle);
        GameObject c2 = Instantiate(coin2, position2, Quaternion.identity);

        gameOver = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (EventSystem.current.IsPointerOverGameObject())  // Check if UI elements touched
        //{
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Check if finger is over a UI element
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                //if (Input.GetMouseButtonDown(0))
           // {
                GameController.gameStart = true;
                Init.SetActive(false);
            }
        }
        /*if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Check if finger is over a UI element
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {*/
        if (!gameOver)
        {
            Score();
        }
        else
        {
            StartCoroutine(GoToGameOver());
        }
    }

    public void CreateCoin1()
    {
        choice1 = Random.Range(1, 18);
        
        while (choice1 == choice2)
        {
            choice1 = Random.Range(1, 18);
        }

        position1 = new Vector2(Mathf.Sin(choice1 / Mathf.PI) * circle, Mathf.Cos(choice1 / Mathf.PI) * circle);
        GameObject c1 = Instantiate(coin1, position1, Quaternion.identity);

    }

    public void CreateCoin2()
    {       
        choice2 = Random.Range(1, 18);
        while (choice1 == choice2)
        {
            choice2 = Random.Range(1, 18);
        }

        position2 = new Vector2(Mathf.Sin(choice2 / Mathf.PI) * circle, Mathf.Cos(choice2 / Mathf.PI) * circle);
        GameObject c2 = Instantiate(coin2, position2, Quaternion.identity);
    }

    public void Score()
    {
        SCORE.text = "" + GameObject.FindObjectOfType<PlayerController>().score;
    }

    IEnumerator GoToGameOver()
    {
        yield return new WaitForSeconds(0.9f);
        gameOver = gameStart = false;
        MissileController.hitCount = 0;
        SceneManager.LoadScene("GameOver");
    }

    public void LauncherAudio()
    {
        audioSource.PlayOneShot(audioClip[0]);
    }

    public void ExplosionAudio()
    {
        audioSource.PlayOneShot(audioClip[2]);
    }

    public void CoinPickupAudio()
    {
        audioSource.PlayOneShot(audioClip[1]);
    }



}
