    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerComponent : MonoBehaviour
{
    public List<GameObject> triggerObjects;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach(GameObject triggerObject in triggerObjects)
        {
            if (triggerObject.activeSelf)
            {
                triggerObject.SetActive(false);
            }
            else
            {
                triggerObject.SetActive(true);
            }
        }

        GetComponent<AudioSource>().Play();
    }
}
