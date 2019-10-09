using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{

    public int time;

    public int type;

    public BugsDisappearing manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("SetUnactive");
    }

    IEnumerator SetUnactive()
    {


        yield return new WaitForSeconds(time);

        switch(type){

            case 1:

                manager.passedFrase1 = true;

                break;

        }

        this.gameObject.SetActive(false);

    }
}
