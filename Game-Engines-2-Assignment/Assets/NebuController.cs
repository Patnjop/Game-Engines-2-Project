﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebuController : MonoBehaviour
{
    public Transform sentinelles;
    public int wakeDistance, jitterDistance, EMPDistance, EMPCount;
    public float EMPseconds;
    public ParticleSystem ps;
    public Transform laserpoint;
    public Boid b;
    public GameObject[] Lights;
    public GameObject[] SentinelleArray;
    public GameObject Sentinelles2;
    public GameObject Sentinelles3;
    public GameObject Sentinelles4;
    public GameObject Sentinelles5;
    public GameObject finalTarget;
    public GameObject laser;
    public GameObject CameraPrefab, SentCam, OldCamera, PathAlt;
    bool changed = false, newCamera = false, changed2 = false, test = false, slowdown = false, shooting = false, sentinellescollected = false;
    public bool EMPUsed = false, canActivate = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("disable");
        b = GetComponent<Boid>();
    }

    // Update is called once per frame
    void Update()
    {
        //follow initial path while they are far away
        if (Vector3.Distance(sentinelles.position, this.transform.position) < wakeDistance && Vector3.Distance(sentinelles.position, this.transform.position) > jitterDistance && changed == false)
        {
            this.GetComponent<FollowPath>().enabled = true;
            changed = true;
        }
        //activate other sentinelles and switch speed and behaviour
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
            sentinellescollected = true;
        }
        //create array of sentinelles
        if (sentinellescollected = true && SentinelleArray.Length < 172)
        {
            SentinelleArray = GameObject.FindGameObjectsWithTag("Enemy");
        }
        //set off EMP
        if (Vector3.Distance(sentinelles.position, transform.position) < EMPDistance && Time.time > 53)
        {
            changed2 = true;
            //Debug.Log("biggle");
            if (EMPUsed == false)
            {
                StartCoroutine("EMP");     
            }
            if (newCamera == false)
            {
                OldCamera.SetActive(false);
                GameObject Camera = GameObject.Instantiate(CameraPrefab,
                new Vector3((transform.position.x - 100), (transform.position.y - 200), (transform.position.z - 1000)), Quaternion.identity);
                StartCoroutine("CameraSwitch");
            }
        }
        //pick a target for shooting
        foreach (GameObject sent in SentinelleArray)
        {
            if (Vector3.Distance(transform.position, sent.transform.position) < 85)
            {
                if (shooting == false && canActivate == false)
                {
                    StartCoroutine("Shoot");
                }
                shooting = true;
            }
        }
        if (EMPCount == 1)
        {
            EMPseconds = 0.75f;
        }
        if (EMPCount == 2)
        {
            StartCoroutine("CameraSwitch2");
        }
        //setup CoRoutines to turn off lights
        if (slowdown == true)
        {
            if (GetComponent<Boid>().maxSpeed > 5)
            {
                GetComponent<Boid>().maxSpeed = Vector3.Distance(transform.position, finalTarget.transform.position) / 10;
            }
            else if (GetComponent<Boid>().maxSpeed <= 5)
            {
                GetComponent<Boid>().maxSpeed = 0;
                StartCoroutine("SwitchOff");
            }
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.2f);
        Vector3 location = transform.TransformPoint(laserpoint.position);
        GameObject Bullet = Instantiate(laser, laserpoint.position, Quaternion.identity);
        shooting = false;
        //Bullet.transform.SetParent(transform);
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
        if (test == false)
        {
            EMPCount++;
            test = true;
        }
        EMPUsed = true;
        GetComponent<Flee>().enabled = false;
        GetComponent<FollowPath>().enabled = true;
        GetComponent<FollowPath>().path = PathAlt.GetComponent<Path>();
        StartCoroutine("EMPReset");
    }
    IEnumerator EMPReset()
    {
        yield return new WaitForSeconds(15f);
        test = false;
        EMPUsed = false;
    }

    IEnumerator CameraSwitch()
    {
        newCamera = true;
        yield return new WaitForSeconds(9f);
        CameraPrefab.SetActive(false);
        SentCam.SetActive(true);
    }

    IEnumerator CameraSwitch2()
    {
        yield return new WaitForSeconds(14f);
        SentCam.SetActive(false);
        OldCamera.SetActive(true);
        yield return new WaitForSeconds(2f);
        slowdown = true;
    }

    IEnumerator SwitchOff()
    {
        canActivate = true;
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < Lights.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Lights[i].SetActive(false);
        }
    }
}
