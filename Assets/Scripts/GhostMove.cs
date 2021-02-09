using UnityEngine;
using System.Collections;

public class GhostMove : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 0.3f;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume=0.5f;
    int cur = 0;
    void FixedUpdate()
    {
        if (transform.position != waypoints[cur].position)
        {
            Vector2 p = Vector2.MoveTowards(transform.position,
                                            waypoints[cur].position,
                                            speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        else cur = (cur + 1) % waypoints.Length;

        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(clip, volume);
            Destroy(other.gameObject);
        }
    }
}