using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPaysage : MonoBehaviour
{
    public GameObject paysage;
    // Start is called before the first frame update
    void Start()
    {
        paysage.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<HingeJoint>().angle > 0)
        {
            paysage.GetComponent<Animator>().enabled = true;
        }
        else if (gameObject.GetComponent<HingeJoint>().angle <= 0)
        {
            paysage.GetComponent<Animator>().enabled = false;
        }
    }
}
