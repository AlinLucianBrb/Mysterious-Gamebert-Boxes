using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveComponent : MonoBehaviour
{
    ParticleSystem[] particleSystems;
    public float waitTime = 2f;

    Transform player;
    float distance = 3;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

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

        if(Vector3.Distance(player.position, transform.position) < distance)
        {
            player.GetComponent<CheckPointComponent>().Respawn();
        }

        GetComponent<AudioSource>().Play();

        foreach (ParticleSystem particleSystem in particleSystems)
        {
            particleSystem.Play();
        }
    }
}
