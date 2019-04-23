using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Playthrough");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Playthrough()
    {
        yield return new WaitForSeconds(42.5f);
        Camera1.SetActive(false);
        Camera2.SetActive(true);
    }
}
