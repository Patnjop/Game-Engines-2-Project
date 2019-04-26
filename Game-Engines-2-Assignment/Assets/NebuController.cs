using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebuController : MonoBehaviour
{
    public Transform sentinelles;
    public int wakeDistance, jitterDistance, EMPDistance;
    public float EMPseconds;
    public ParticleSystem ps;
    public Boid b;
    public GameObject Sentinelles2;
    public GameObject Sentinelles3;
    public GameObject Sentinelles4;
    bool changed = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("disable");
        b = GetComponent<Boid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(sentinelles.position, this.transform.position) < wakeDistance && Vector3.Distance(sentinelles.position, this.transform.position) > jitterDistance && changed == false)
        {
            this.GetComponent<FollowPath>().enabled = true;
            changed = true;
        }
        if (Vector3.Distance(sentinelles.position, this.transform.position) < jitterDistance)
        {
            this.GetComponent<FollowPath>().enabled = false;
            this.GetComponent<JitterWander>().enabled = true;
            b.maxSpeed = 100;
            b.maxForce = 20;
            Sentinelles2.SetActive(true);
            Sentinelles3.SetActive(true);
            Sentinelles4.SetActive(true);
        }
        if (Vector3.Distance(sentinelles.position, transform.position) < EMPDistance)
        {
            StartCoroutine("EMP");
        }
    }

    IEnumerator disable()
    {
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<FollowPath>().enabled = false;
        this.GetComponent<JitterWander>().enabled = false;
    }

    IEnumerator EMP()
    {
        yield return new WaitForSeconds(EMPseconds);
        ps.Play();
    }
}
