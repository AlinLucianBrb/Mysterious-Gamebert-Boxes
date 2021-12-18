using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveComponent : MonoBehaviour
{
    ParticleSystem[] particleSystems;
    public float waitTime = 2f;
    void Start()
    {
        particleSystems = GetComponentsInChildren<ParticleSystem>();
        foreach(ParticleSystem particleSystem in particleSystems)
        {
            particleSystem.Stop();
        }       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {     
        foreach (ParticleSystem particleSystem in particleSystems)
        {
            if (particleSystem.isPlaying)
            {
                return;
            }
        }

        StartCoroutine(WaitAndPlay(waitTime));
    }

    IEnumerator WaitAndPlay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        foreach (ParticleSystem particleSystem in particleSystems)
        {
            particleSystem.Play();
        }
    }
}
