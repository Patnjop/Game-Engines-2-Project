using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour
{
    public GameObject ship;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ship.GetComponent<NebuController>().EMPCount == 2)
        {
            GetComponent<Seek>().enabled = false;
        }
    }
}
