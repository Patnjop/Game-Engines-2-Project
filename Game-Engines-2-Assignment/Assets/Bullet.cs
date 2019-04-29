using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform LookPoint;
    Vector3 spawnpoint, direction;
    public GameObject ship;
    public int rnd;
    // Start is called before the first frame update
    void Start()
    {
        ship = GameObject.Find("Nebuchannezzar");
        spawnpoint = transform.position;
        LookPoint = GameObject.FindGameObjectWithTag("Lookpoint").transform;
        StartCoroutine("Death");
        rnd = Random.Range(1, 171);
        direction = ship.GetComponent<NebuController>().SentinelleArray[rnd].transform.position - spawnpoint;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * 0.03f);
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(this.gameObject);
    }
}
