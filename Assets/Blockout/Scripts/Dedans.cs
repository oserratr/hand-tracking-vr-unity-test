using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dedans : MonoBehaviour
{
    // declare un bool pour savoir si le joueur est dedans
    public bool isDedans = false;

    // Quand trigger est enter par le tag "Hand" play le son
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            // On est dedans
            isDedans = true;
            // On appelle la fonction StateChanged de FenetreState
            GetComponentInParent<FenetreState>().StateChanged();
        }
    }
    // Quand trigger est exit par le tag "Hand" play le son
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
            // On n'est plus dedans
            isDedans = false;
            // On appelle la fonction StateChanged de FenetreState
            GetComponentInParent<FenetreState>().StateChanged();
        }
    }
}
