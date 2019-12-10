using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    private Vector3 paddleToBallVector;
    public float speed;
    private bool hasStarted = false;
    bool hasClicked;
   

    // Use this for initialization
    void Start ()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        hasClicked = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hasStarted != true)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;
        }
        if (Input.GetMouseButtonDown(0) && hasClicked == false)
        {
            print("Mouse clicked, lauch ball!");
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(3f, speed);
            hasClicked = true;
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(-0.3f, 0.3f), Random.Range(0f, 0.3f));
        if (hasStarted)
        {
            GetComponent<AudioSource>().Play(18);
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
