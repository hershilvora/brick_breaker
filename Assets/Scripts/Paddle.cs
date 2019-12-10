using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
    private Ball ball;
    public bool autoPlay = false;
	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }

    }

    void MoveWithMouse()
    {
        float mousePosition = Input.mousePosition.x / Screen.width * 8;

        if (mousePosition > 7.5)
        {
            mousePosition = 7.5f;
        }
        else if (mousePosition < 0.5)
        {
            mousePosition = 0.5f;
        }

        Vector3 paddlePos = new Vector3(mousePosition, 0.16016f, 0);
        this.transform.position = paddlePos;
    }

    void AutoPlay()
    {
        Vector3 autoPaddlePos = new Vector3(ball.transform.position.x, 0.16016f, 0);

        if(ball.transform.position.y < 1.123f)
        {
            this.transform.position = autoPaddlePos;
        } 

       
    }
}
