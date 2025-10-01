
/*This script handles the floating texts appearing whenever the player get close to rooms and offices, detailing the
information about them.*/
using UnityEngine;

public class SimpleFloatingText : MonoBehaviour
{
    public GameObject floatingTextCanvas; // Reference to the Canvas containing TextMeshPro

    /*Nothing needs to happen at the start, the texts given to the floating texts are given by another script, ,
    which receives those texts from a database*/
    void Start()
    {
        // Ensure the text starts disabled
        // if (floatingTextCanvas)
        // {
        //     floatingTextCanvas.SetActive(false);
        // }
    }

    /*Whenever the user gets inside the trigger area of each room, the panel/canvas containing the information for the
    triggered room is activated(visible) and the data given to it by the script handling the database responsible for their assignments
    is shown.*/
    void OnTriggerEnter(Collider other)
    {
        //We make sure that only the user, who has a tag 'Player', is counted when triggers are happening.
        if (other.CompareTag("Player"))
        {
            //The flowing text is showed
            floatingTextCanvas.SetActive(true);
        }
    }

    /*Whenever the user gets away frokm the trigger area, the panel/canvas containing the information for the triggered room 
    gets hidden(not visible)*/
    void OnTriggerExit(Collider other)
    {
        // Check if the player exits the trigger zone
        if (other.CompareTag("Player"))
        {
            //The flowing text is hidden
            floatingTextCanvas.SetActive(false);
        }
    }
}
