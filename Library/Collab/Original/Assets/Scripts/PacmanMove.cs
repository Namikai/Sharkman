using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PacmanMove : MonoBehaviour {

    public float speed = 0.4f;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume=0.5f;
    public Text score;
    public int scoreValue = 0;

    Vector2 dest = Vector2.zero;

    void Start() {
        dest = transform.position;
        score.text = scoreValue.ToString();
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
    }
    void Update()
    {
        if(scoreValue == 1645 && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("maze1"))
        {
            SceneManager.LoadScene("maze2");
        }
        if(scoreValue == 1420 && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("maze2"))
        {
            SceneManager.LoadScene("Credits");
        }
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
            scoreValue += 5;
            score.text = "Score: " + scoreValue.ToString();
    }
}