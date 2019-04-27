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
        Debug.Log("Ouch");
        if (o != null)
        {
            o.enabled = false;
        }
        s.enabled = false;
        this.GetComponent<SentinelleBehaviours>().EMPed = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<SentinelleBehaviours>().EMPed == true)
        {
            if (o != null)
            {
                o.enabled = false;
            }
            s.enabled = false;
        }
    }
}
