using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{

    public GameObject targ, hand;

    public string moveTo;

    public float speed, mag;

    // Start is called before the first frame update
    void Start()
    {
        targ = GameObject.Find("MoveTo");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (hand == null)
        {
            hand = GameObject.Find("HandRight");
            gameObject.GetComponent<TrailRenderer>().emitting = false;
        }
        else
        {
            if (hand.activeSelf)
            {
                gameObject.GetComponent<TrailRenderer>().emitting = true;
                if (Vector2.Distance(gameObject.transform.position, targ.transform.position) < 25)
                {
                    mag = 0.1f;
                }
                else
                {
                    mag = 500 / Vector2.Distance(gameObject.transform.position, targ.transform.position);
                }

                transform.position = Vector3.MoveTowards(transform.position, targ.transform.position, speed * mag);
            }
        }
        
        
    }
}
