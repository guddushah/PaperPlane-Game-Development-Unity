using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MissileController : MonoBehaviour {

    public static float missileSpeed = 0.05f;
    public GameObject explosionFx;
    public float posPredX;
    public float posPredY;
    public Vector3 direction;
    public GameObject Target;
    public static int hitCount = 0;

    // Use this for initialization
    void Start () {
        Target = GameObject.Find("Plane");

        posPredX = Mathf.Sin((PlayerController.rotationTime + Random.Range(0.1f * PlayerController.dir, 1.8f * PlayerController.dir)) * (PlayerController.rotationSpeed + (float) 1/20) * Mathf.PI) * PlayerController.Radius;
        posPredY = Mathf.Cos((PlayerController.rotationTime + Random.Range(0.1f * PlayerController.dir, 1.8f * PlayerController.dir)) * (PlayerController.rotationSpeed + (float) 1/ 20) * Mathf.PI) * PlayerController.Radius; ;

        direction = (Target.transform.position + new Vector3(posPredX, posPredY, 0)) - transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction.normalized * missileSpeed ,Space.World);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            hitCount++;
            Destroy(gameObject);
            if (PlayerController.currentPlaneChoice == 1 && hitCount == PlayerController.canTakeHit)
            {
                Destroy(collision);
            }
            else if (PlayerController.currentPlaneChoice == 2 && hitCount == PlayerController.canTakeHit)
            {
                Destroy(collision);
            }
            else if (PlayerController.currentPlaneChoice == 3 && hitCount == PlayerController.canTakeHit)
            {
                Destroy(collision);
            }

            else if (PlayerController.currentPlaneChoice == 4 && hitCount == PlayerController.canTakeHit)
            {
                Destroy(collision);
            }

        }
    }

    public void Destroy(Collision2D collision)
    {   
        GameController.gameOver = true;
        GameController.gameStart = false;
        Instantiate(explosionFx, collision.collider.gameObject.transform.position, Quaternion.identity);
        GameObject.FindObjectOfType<GameController>().ExplosionAudio();
        Destroy(collision.collider.gameObject);
       
    }  
}
