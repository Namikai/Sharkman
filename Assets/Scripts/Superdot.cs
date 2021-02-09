using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superdot : MonoBehaviour
{
    public GameObject blinky;
    public GameObject Octopus2;
    public GameObject Octopus3;
    public GameObject Octopus4;
    public float timeRemaining = 5;
    public bool timerIsRunning = false;
    private GhostMove ghostMove;

    void Awake()
    {
        ghostMove = blinky.GetComponent<GhostMove>();
        ghostMove = Octopus2.GetComponent<GhostMove>();
        ghostMove = Octopus3.GetComponent<GhostMove>();
        ghostMove = Octopus4.GetComponent<GhostMove>();
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                Octopus2.SetActive(false);
                blinky.SetActive(false);
                Octopus3.SetActive(false);
                Octopus4.SetActive(false);
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("time has run out");
                Octopus2.SetActive(true);
                blinky.SetActive(true);
                Octopus3.SetActive(true);
                Octopus4.SetActive(true);
                timerIsRunning = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.tag == "Player")
            transform.position = new Vector3(-100, -100, -10);
            timerIsRunning = true;
    }
}
