using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
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


        yield return new WaitForSeconds(1f);

        this.gameObject.SetActive(false);

    }
}
