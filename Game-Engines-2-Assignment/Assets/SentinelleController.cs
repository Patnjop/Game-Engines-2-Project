using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelleController : MonoBehaviour
{
    public GameObject Ship;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, Ship.transform.position) < 100)
        {
            GetComponent<Boid>().maxSpeed = 155;
            GetComponent<Boid>().maxForce = 31;
        }
    }
}
