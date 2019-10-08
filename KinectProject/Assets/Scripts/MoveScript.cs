using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    public int areaXMin, areaXMax, areaYMin, areaYMax;

    public float accelerationTime = 1f;
    public float maxSpeed = 3f;
    private Vector2 oldMovement, movement;
    private float timeLeft;

    public Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    public float speed = 2f;
    public float maxRotation = 45f;

    void Update()
    {
        transform.rotation = Quaternion.Euler( 0f, 0f, maxRotation * Mathf.Sin(Time.time * speed));
    }

    /*
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            oldMovement = movement;
            movement = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
            timeLeft += accelerationTime;



            var angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }

        if(transform.position.x <= areaXMin)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(700, -130), 30);
            //transform.position = new Vector2 (areaXMax,transform.position.y);
        }

        if (transform.position.x >= areaXMax)
        {
           // transform.position = new Vector2(areaXMin, transform.position.y);
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(700, -130), 30);
        }

        if (transform.position.y <= areaYMin)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(700, -130), 30);
            //transform.position = new Vector2(transform.position.x, areaYMax);
        }

        if (transform.position.y >= areaYMax)
        {
            //transform.position = new Vector2(transform.position.x, areaYMin);
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(700, -130), 30);

        }

        
    }
    */
    void FixedUpdate()
    {
        //rb.AddForce(movement * 0.1f * maxSpeed);
        
    }
}
