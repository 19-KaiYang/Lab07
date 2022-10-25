using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public float velocity = 2.4f;
    private Rigidbody rigidbody;

    private int score = 0;

    public GameObject Obstacles;
    public GameObject box;
    public Text ScoreText;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        Obstacles = GameObject.FindWithTag("Obstacle");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rigidbody.velocity = Vector2.up * velocity;

        }

        
        

       
            

    }
    public void OnCollisionEnter(Collision collider)
    {
        if(collider.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Scoring")
        {
            score++;
            ScoreText.text = "SCORE: " + score;
        }
    }
}
