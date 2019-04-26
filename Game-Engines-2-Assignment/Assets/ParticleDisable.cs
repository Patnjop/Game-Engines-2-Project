using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDisable : MonoBehaviour
{
    OffsetPursue o;
    Seek s;
    // Start is called before the first frame update
    void Start()
    {
        o = this.GetComponent<OffsetPursue>();
        s = GetComponent<Seek>();
    }

    private void OnParticleCollision(GameObject other)
    {
        o.enabled = false;
        s.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
