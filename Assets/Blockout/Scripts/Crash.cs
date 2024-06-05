using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    public AudioSource crashSound;
    public AudioSource openSound;
    public Devant devant;
    public Animator animator;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            // Jouer le son de crash
            crashSound.Play();
            // Trigger the animator called "Wiggle"
            animator.SetTrigger("Wiggle");

        }

    }
    // Quand on sort du trigger 
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            if (devant.isDevant)
            {
                // Jouer le son de crash
                openSound.Play();
                // Trigger the animator called "Wiggle"
                animator.SetBool("Open", true);
            }
            else
            {
                // Trigger the animator called "Close"
                animator.SetBool("Open", false);
            }
        }
    }
    // Fonction Fermer
    public void Fermer()
    {
        // Trigger the animator called "Close"
        animator.SetBool("Open", false);
    }
}
