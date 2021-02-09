using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PacmanMove : MonoBehaviour {

    public float speed = 0.4f;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume=0.5f;
    public Text score;
    private int scoreValue = 0;


    Vector2 dest = Vector2.zero;

    void Start() {
        dest = transform.position;
        score.text = scoreValue.ToString();
    }

    void FixedUpdate()
    {
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        if ((Vector2)transform.position == dest)
        {
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;
            if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
                dest = (Vector2)transform.position - Vector2.up;
            if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
                dest = (Vector2)transform.position - Vector2.right;
        }

        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }
    
    bool valid(Vector2 dir) {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.tag == "pickup")
            audioSource.PlayOneShot(clip, volume);
            scoreValue += 1;
            score.text = "Score: " + scoreValue.ToString();
    }
}