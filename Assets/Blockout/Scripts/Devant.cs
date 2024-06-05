using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devant : MonoBehaviour
{
    // declare un bool pour savoir si le joueur est devant
    public bool isDevant = false;

    // Quand on entre dans le trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            // On est devant
            isDevant = true;
            // On appelle la fonction StateChanged de FenetreState
            GetComponentInParent<FenetreState>().StateChanged();
        }
    }
    // Quand on sort du trigger
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            // On n'est plus devant
            isDevant = false;
            // On appelle la fonction StateChanged de FenetreState
            GetComponentInParent<FenetreState>().StateChanged();
        }
    }
}
