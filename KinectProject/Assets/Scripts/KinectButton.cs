using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinectButton : MonoBehaviour
{
    public Sprite[] faseSprite;

    public GameObject bugsDisappearingGameObj;
    private BugsDisappearing bugsDisappearingScript;

    public bool instructionPart;

    // Start is called before the first frame update
    void Start()
    {
        bugsDisappearingScript = bugsDisappearingGameObj.GetComponent<BugsDisappearing>();
    }

    // Update is called once per frame
    void Update()
    {
        if (instructionPart)
        {
            StartCoroutine("Flash");
        }

        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        bugsDisappearingScript.disappearing = true;

        bugsDisappearingScript.kinectIconRederer.sprite = faseSprite[1];
    }

    void OnTriggerExit2D(Collider2D col)
    {
        bugsDisappearingScript.disappearing = false;

        bugsDisappearingScript.kinectIconRederer.sprite = faseSprite[0];

    }

    IEnumerator Flash()
    {
        instructionPart = false;


        yield return new WaitForSeconds(0.5f);

        bugsDisappearingScript.kinectIconRederer.sprite = faseSprite[1];

        yield return new WaitForSeconds(0.5f);

        bugsDisappearingScript.kinectIconRederer.sprite = faseSprite[0];

        yield return new WaitForSeconds(0.5f);

        bugsDisappearingScript.kinectIconRederer.sprite = faseSprite[1];

        yield return new WaitForSeconds(0.5f);

        bugsDisappearingScript.kinectIconRederer.sprite = faseSprite[0];

        yield return new WaitForSeconds(0.5f);

        bugsDisappearingScript.kinectIconRederer.sprite = faseSprite[1];

        yield return new WaitForSeconds(0.5f);

        bugsDisappearingScript.kinectIconRederer.sprite = faseSprite[0];

        yield return new WaitForSeconds(0.5f);

        bugsDisappearingScript.kinectIconRederer.sprite = faseSprite[1];

        yield return new WaitForSeconds(0.5f);

        bugsDisappearingScript.kinectIconRederer.sprite = faseSprite[0];


    }

}
