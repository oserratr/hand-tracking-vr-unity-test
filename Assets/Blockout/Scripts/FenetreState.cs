using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenetreState : MonoBehaviour
{
    //declarer 3 etats de la fenetre : fermée, entreouverte, ouverte
    public enum FenetreEtat { fermee, entreouverte, opening, ouverte, wind };
    public FenetreEtat etat = FenetreEtat.fermee;
    public GameObject devant;
    public GameObject dedans;

    public AudioSource wiggle;
    public AudioSource open;
    public AudioSource close;

    public float timeToClose = 5f;

    public Animator animator;

    // function to reset all triggers
    public void ResetTriggers()
    {
        animator.ResetTrigger("Fermee");
        animator.ResetTrigger("EntreOuverte");
        animator.ResetTrigger("Opening");
        animator.ResetTrigger("Wind");
    }

    public void StateChanged()
    {
        // si l'etat est fermee et que le joueur est dedans
        if (etat == FenetreEtat.fermee && dedans.GetComponent<Dedans>().isDedans && !devant.GetComponent<Devant>().isDevant)
        {
            // on passe a l'etat entreouverte
            etat = FenetreEtat.entreouverte;
            // on passe a l'etat entreouverte
            ResetTriggers();
            animator.SetTrigger("EntreOuverte");
            //jour le son de la fenetre qui s'ouvre
            wiggle.Play();
        }
        else if (etat == FenetreEtat.entreouverte && !dedans.GetComponent<Dedans>().isDedans && !devant.GetComponent<Devant>().isDevant)
        {
            // on passe a l'etat fermée
            etat = FenetreEtat.fermee;
            // on passe a l'etat fermée
            ResetTriggers();
            animator.SetTrigger("Fermee");
            //jour le son de la fenetre qui se ferme
            close.Play();
        }
        else if (etat == FenetreEtat.entreouverte && !dedans.GetComponent<Dedans>().isDedans && devant.GetComponent<Devant>().isDevant)
        {
            // demarrer la coroutine pour ouvrir la fenetre
            StartCoroutine(OpenWindowCoroutine());
        }

    }


    //coroutine pour attendre l'animation qui s'apelle "Open" dans l'animator
    IEnumerator OpenWindowCoroutine()
    {
        //jouer le son de la fenetre qui s'ouvre
        open.Play();
        ResetTriggers();
        animator.SetTrigger("Opening");
        // on passe a l'etat ouverte
        etat = FenetreEtat.opening;
        //chercher la durée de l'animation qui se trouve dans l'etat "Open" de l'animator
        float openLength = 1.0f;
        //attendre 2 secondes
        yield return new WaitForSeconds(openLength);
        // on passe a l'etat "ouverte"
        etat = FenetreEtat.ouverte;
        // Attendre 2 secondes
        yield return new WaitForSeconds(timeToClose);
        // On la ferme
        etat = FenetreEtat.wind;
        // On joue le son de la fenetre qui se ferme
        close.Play();
        ResetTriggers();
        animator.SetTrigger("Wind");
        //chercher la durée de l'animation qui se trouve dans l'etat "Wind" de l'animator
        float windLength = 1.0f;
        // Attendre l'animation de fermeture
        yield return new WaitForSeconds(windLength);
        ResetTriggers();
        animator.SetTrigger("Fermee");
        etat = FenetreEtat.fermee;
    }

}
