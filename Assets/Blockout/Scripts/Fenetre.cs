using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fenetre : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textAnimationFenetre;
    public GameObject animationFenetre;

    public GameObject outFenetre;

    void Start()
    {
        textAnimationFenetre.SetActive(false);
        animationFenetre.SetActive(false);
        outFenetre.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(this.name + "Trigger enter with other" + other.name);
        textAnimationFenetre.SetActive(true);
        animationFenetre.SetActive(true);
        outFenetre.SetActive(false);
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log(this.name + "Trigger exit with other" + other.name);

        textAnimationFenetre.SetActive(false);
        animationFenetre.SetActive(false);
        outFenetre.SetActive(true);

    }

}
