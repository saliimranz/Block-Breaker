using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Paddle paddle;
    private Brick brick;
    private bool hasStarted = false;
    public AudioSource audio;
    private Vector3 paddleToBallVector;
    public Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        brick = GameObject.FindObjectOfType<Brick>();
       // audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            // lock the ball at paddle at start
            this.transform.position = paddle.transform.position + paddleToBallVector;


            // press mouse to launch the ball
            if (Input.GetMouseButtonDown(0))
            {
                print("Mouse clicked!!");
                hasStarted = true;
                this.rb2d.velocity = new Vector2(2.0f, 10.0f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(0f, 0.2f));
       // if(hasStarted && !brick.isBreakable) { audio.Play(); }
        rb2d.velocity += tweak;
    }
}
