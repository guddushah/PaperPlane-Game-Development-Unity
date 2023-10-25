using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public float rotationZ;
    public float speed;
    public bool canCreateMissile;
    public GameObject Missile;
    public bool readyToLaunch;
    // Use this for initialization
    void Start()
    {
        rotationZ = 0;
        speed = 5f;
        canCreateMissile = true;
        readyToLaunch = false;
        StartCoroutine(LaunchNow());
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.gameOver && GameController.gameStart)
        {
            if (canCreateMissile && readyToLaunch)
            {
                CreateMissile();
            }
            rotationZ += (Time.deltaTime + PlayerController.dir) * -PlayerController.rotationSpeed * speed;
            transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        }     
    }

    private void CreateMissile()
    {
        canCreateMissile = false;
        GameObject bullet = Instantiate(Missile, transform.position, Quaternion.identity);
        GameObject.FindObjectOfType<GameController>().LauncherAudio();
        StartCoroutine(WaitForNextLaunch());
    }

    IEnumerator WaitForNextLaunch()
    {
        yield return new WaitForSeconds(0.8f);
        canCreateMissile = true;
    }

    IEnumerator LaunchNow()
    {
        yield return new WaitForSeconds(0.5f);
        readyToLaunch = true;
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
