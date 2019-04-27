using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerScript : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        other.GetComponent<Seek>().enabled = false;
        if (other.GetComponent<OffsetPursue>() != null)
        {
            other.GetComponent<OffsetPursue>().enabled = false;
        }
        Debug.Log("oi");
    }
}
