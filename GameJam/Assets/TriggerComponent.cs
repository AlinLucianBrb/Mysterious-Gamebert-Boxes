    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerComponent : MonoBehaviour
{
    public GameObject triggerObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(triggerObject.activeSelf)
        {
            triggerObject.SetActive(false);
        }
        else
        {
            triggerObject.SetActive(true);
        }
    }
}
