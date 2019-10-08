using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScriptBackground : MonoBehaviour
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

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            oldMovement = movement;
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft += accelerationTime;


            
        }

        if(transform.position.x < areaXMin)
        {
            transform.position = new Vector2 (areaXMax,transform.position.y);
        }

        if (transform.position.x > areaXMax)
        {
            transform.position = new Vector2(areaXMin, transform.position.y);
        }

        if (transform.position.y < areaYMin)
        {
            transform.position = new Vector2(transform.position.x, areaYMax);
        }

        if (transform.position.y > areaYMax)
        {
            transform.position = new Vector2(transform.position.x, areaYMin);
        }
        
        
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * 0.1f * maxSpeed);
        

        //var angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
