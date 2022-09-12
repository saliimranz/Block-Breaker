using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool autoPlay = false;
    private Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            Autopaly();
        }
    }

    void Autopaly()
    {
        Vector3 paddlePos = new Vector3(8.0f, transform.position.y, -1);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);
        this.transform.position = paddlePos;
    }
    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(8.0f, transform.position.y, -1);
        float PosInBlocks = (Input.mousePosition.x / Screen.width) * 16;
        paddlePos.x = Mathf.Clamp(PosInBlocks, 0.5f, 15.5f);
        this.transform.position = paddlePos;
    }
}
