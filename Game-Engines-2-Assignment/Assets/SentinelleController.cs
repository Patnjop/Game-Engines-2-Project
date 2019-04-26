using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelleController : MonoBehaviour
{
    public List<Boid> boids = new List<Boid>();
    public GameObject Ship;
    public GameObject[] Sentinelles;

    // Start is called before the first frame update
    void Start()
    {
        Sentinelles = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject s in Sentinelles)
        {
            boids.Add(s.GetComponent<Boid>());
        }      
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, Ship.transform.position) < 100)
        {
            for (int i = 0; i < boids.Count; i++)
            {
                Sentinelles[i].GetComponent<OffsetPursue>().enabled = false;
                boids[i].maxSpeed = 125;
                boids[i].maxForce = 30;
            }
        }
    }
}
