using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebuController : MonoBehaviour
{
    public Transform sentinelles;
    public int wakeDistance, jitterDistance, EMPDistance, EMPCount;
    public float EMPseconds;
    public ParticleSystem ps;
    public Boid b;
    public GameObject Sentinelles2;
    public GameObject Sentinelles3;
    public GameObject Sentinelles4;
    public GameObject Sentinelles5;
    public GameObject CameraPrefab, SentCam, OldCamera, PathAlt;
    bool changed = false, newCamera = false, changed2 = false, test = false;
    public bool EMPUsed = false;
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
        if (Vector3.Distance(sentinelles.position, this.transform.position) < jitterDistance && changed2 == false)
        {
            this.GetComponent<FollowPath>().enabled = false;
            this.GetComponent<Flee>().enabled = true;
            b.maxSpeed = 100;
            b.maxForce = 20;
            Sentinelles2.SetActive(true);
            Sentinelles3.SetActive(true);
            Sentinelles4.SetActive(true);
            Sentinelles5.SetActive(true);
        }

        if (Vector3.Distance(sentinelles.position, transform.position) < EMPDistance && Time.time > 53)
        {
            changed2 = true;
            Debug.Log("biggle");
            if (EMPUsed == false)
            {
                StartCoroutine("EMP");
                if (test == false)
                {
                    EMPCount++;
                    test = true;
                }
            }
            if (newCamera == false)
            {
                OldCamera.SetActive(false);
                GameObject Camera = GameObject.Instantiate(CameraPrefab,
                new Vector3((transform.position.x - 100), (transform.position.y - 200), (transform.position.z - 1000)), Quaternion.identity);
                StartCoroutine("CameraSwitch");
            }
        }
        if (EMPCount == 2)
        {
            StartCoroutine("CameraSwitch2");
        }
    }

    IEnumerator disable()
    {
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<FollowPath>().enabled = false;
        this.GetComponent<Flee>().enabled = false;
    }

    IEnumerator EMP()
    {
        yield return new WaitForSeconds(EMPseconds);
        ps.Play();
        EMPUsed = true;
        GetComponent<Flee>().enabled = false;
        GetComponent<FollowPath>().enabled = true;
        GetComponent<FollowPath>().path = PathAlt.GetComponent<Path>();
        StartCoroutine("EMPReset");
    }
    IEnumerator EMPReset()
    {
        yield return new WaitForSeconds(5f);
        test = false;
        EMPUsed = false;
    }

    IEnumerator CameraSwitch()
    {
        newCamera = true;
        yield return new WaitForSeconds(12f);
        CameraPrefab.SetActive(false);
        SentCam.SetActive(true);
    }

    IEnumerator CameraSwitch2()
    {
        yield return new WaitForSeconds(1f);
        SentCam.SetActive(false);
        OldCamera.SetActive(true);
    }
}
