using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emiter : MonoBehaviour
{

    public GameObject[] germs;
    public bool disappearing;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        
        //StartCoroutine("Appear");
        
    }


    

    IEnumerator Appear()
    {
        for (int i = 0; i < germs.Length; i++)
        {
            if (germs[i].activeSelf == false)
            {
                germs[i].SetActive(true);
                germs[i].transform.position = transform.position + new Vector3(Random.Range(-400.0f, 400.0f), Random.Range(-700.0f, 700.0f), 0);
            }
            yield return new WaitForSeconds(1f);
        }

    }
}
