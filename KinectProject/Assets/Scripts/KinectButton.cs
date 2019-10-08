using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinectButton : MonoBehaviour
{

    public GameObject bugsDisappearingGameObj;
    private BugsDisappearing bugsDisappearingScript;

    // Start is called before the first frame update
    void Start()
    {
        bugsDisappearingScript = bugsDisappearingGameObj.GetComponent<BugsDisappearing>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        bugsDisappearingScript.disappearing = true;

        bugsDisappearingScript.kinectIconRederer.color = Color.red;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        bugsDisappearingScript.disappearing = false;

        bugsDisappearingScript.kinectIconRederer.color = Color.white;

    }
}
