using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerController : MonoBehaviour
{
    public static float Radius = 2.13f;
    public static float rotationSpeed = 0.35f;
    public static float rotationTime;
    public bool canTap;
    public static int dir = 1;
    public Vector3 prevPos;
    public int score = 0;
    public Sprite[] planeCharact;
    public static int currentPlaneChoice;
    public static int currentCoinChoice;
    public static int canTakeHit;
    public bool canMove;
    public bool stage1 = false;
    public bool stage2 = false;
    public bool stage3 = false;
    // Use this for initialization
    void Start()
    {
        canTap = true;
        rotationTime = 0;
        currentPlaneChoice = 1;
        currentCoinChoice = 1;
        canTakeHit = 1;
        PlayerPrefs.SetInt("Score", score);
        canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.gameStart)
        {
            if (Input.GetMouseButtonDown(0) && canTap && !canMove)
            {              
                canTap = false;
                canMove = true;
                StartCoroutine(WaitForTap());
            }

            if (Input.GetMouseButtonDown(0) && canTap && canMove)
            {
                canTap = false;
                dir *= -1;
                StartCoroutine(WaitForTap());
            }

            if (canMove)
            {
                MovePlayer();
            }           
        }
            
    }

    IEnumerator WaitForTap()
    {
        yield return new WaitForSeconds(0.05f);
        canTap = true;
    }

    public void MovePlayer()
    {
        rotationTime += Time.deltaTime * dir;
        transform.position = new Vector2(Mathf.Sin(rotationTime * (rotationSpeed + (float) 1/20) * Mathf.PI) * Radius,
                                          Mathf.Cos(rotationTime * (rotationSpeed + (float)1 / 20) * Mathf.PI) * Radius);

        /*Vector3 direction = transform.position - prevPos;
        transform.rotation = Quaternion.LookRotation(direction);
        prevPos = transform.position;*/

        if (dir == 1)
            transform.rotation = Quaternion.Euler(0, 180, rotationTime * (rotationSpeed + (float)1 / 20) * 180);
        else
            transform.rotation = Quaternion.Euler(0, 0, rotationTime * (rotationSpeed + (float)1 / 20) * -180);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.collider.gameObject.tag == "Coin1")
        {
                GameObject.FindObjectOfType<GameController>().CoinPickupAudio();
                SetScore(1);
                GameObject.FindObjectOfType<GameController>().CreateCoin1();
                Destroy(collision.collider.gameObject);        
        }

        if(collision.collider.gameObject.tag == "Coin2")
        {
            GameObject.FindObjectOfType<GameController>().CoinPickupAudio();
            SetScore(2);
            GameObject.FindObjectOfType<GameController>().CreateCoin2();
            Destroy(collision.collider.gameObject);
        }
    }

    public void SetScore(int count)
    {
        if (count == 1)
        {
            score++;
        }
        else
        {
            score += 2;
        }
       
        PlayerPrefs.SetInt("Score", score);
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            SetHighScore();
        }
        SetPlayer();
    }

   

    public void SetPlayer()
    {
        if(score >= 20 && !stage1)
        {
            stage1 = true;
            MissileController.hitCount = 0;
            canTakeHit = 2;
            currentPlaneChoice = 2;
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = planeCharact[0];
            Destroy(gameObject.transform.GetChild(0).gameObject.GetComponent<PolygonCollider2D>());
            gameObject.transform.GetChild(0).gameObject.AddComponent<PolygonCollider2D>(); 
        }
        else if(score >= 50 && !stage2)
        {
            stage2 = true;
            MissileController.hitCount = 0;
            canTakeHit = 3;
            currentPlaneChoice = 3;
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = planeCharact[1];
            Destroy(gameObject.transform.GetChild(0).gameObject.GetComponent<PolygonCollider2D>());
            gameObject.transform.GetChild(0).gameObject.AddComponent<PolygonCollider2D>();
        }
        else if(score >= 70 && !stage3)
        {
            stage3 = true;
            MissileController.hitCount = 0;
            canTakeHit = 4;
            currentPlaneChoice = 4;
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = planeCharact[2];
            Destroy(gameObject.transform.GetChild(0).gameObject.GetComponent<PolygonCollider2D>());
            gameObject.transform.GetChild(0).gameObject.AddComponent<PolygonCollider2D>();
        }
    }

    public void SetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", score);
    }
}
