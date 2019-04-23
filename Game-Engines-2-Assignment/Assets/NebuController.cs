using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebuController : MonoBehaviour
{
    public Transform sentinelles;
    public int wakeDistance;
    public int jitterDistance;
    public Boid b;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("disable");
        b = GetComponent<Boid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(sentinelles.position, this.transform.position) < wakeDistance && Vector3.Distance(sentinelles.position, this.transform.position) > jitterDistance)
        {
            this.GetComponent<FollowPath>().enabled = true;
        }
        if (Vector3.Distance(sentinelles.position, this.transform.position) < jitterDistance)
        {
            this.GetComponent<FollowPath>().enabled = false;
            this.GetComponent<JitterWander>().enabled = true;
            b.maxSpeed = 100;
            b.maxForce = 20;
        }
    }

    IEnumerator disable()
    {
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<FollowPath>().enabled = false;
        this.GetComponent<JitterWander>().enabled = false;
    }
}
