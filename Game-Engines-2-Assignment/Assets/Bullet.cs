using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform LookPoint;
    public GameObject ship;
    // Start is called before the first frame update
    void Start()
    {
        ship = GameObject.Find("Nebuchannezzar");
        LookPoint = GameObject.FindGameObjectWithTag("Lookpoint").transform;
        transform.LookAt(LookPoint);
        StartCoroutine("Death");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward);
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(this.gameObject);
    }
}
