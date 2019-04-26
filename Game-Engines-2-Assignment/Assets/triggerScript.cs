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
    /*private void OnParticleTrigger()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();

        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];

        }
    }*/
}
