using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seperate : MonoBehaviour
{
    public bool avoided = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //generate force away from other sentinelle
            Vector3 direction = transform.position - other.transform.position;
            transform.Translate(direction * Time.deltaTime);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //reset 
        if (other.tag == "Enemy")
        {
            avoided = true;
        }
    }
}
