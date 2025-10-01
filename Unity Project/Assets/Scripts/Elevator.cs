/*This script handles the elevator usage of the platform*/
using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro; // This is required for TextMeshProUGUI

public class Elevator : MonoBehaviour
{
    public GameObject player; // Assign in Inspector
    public AudioClip ding;
    public AudioClip travel;
    public Transform[] exitPoints; // Assign exit positions in the Inspector
    public float waitTime = 2f; // Time to simulate travel
    public GameObject journeyMessage;
    public GameObject gameO;
    public GameObject toggle1;
    public GameObject toggle2;
    public GameObject languages;
    public GameObject movement_items;
    private string message;

    // private AudioSource audioSource;

    // void Start()
    // {
    //     audioSource = GetComponent<AudioSource>(); // Get AudioSource from GameObject
    // }

    /*This function happens when the user has selected a destination navigation using elevators and one is needed for a floor change.
    When the user triggers(goes close to) the correct elevator, the teleportation process starts*/
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Ensure it's the player
        {
            // Get the PlayerController component from the player GameObject
            WaypointSystem playerScript = player.GetComponent<WaypointSystem>();
            Debug.LogError("now");
            //The condition below checks whether or not the usage of elevators is permitted, with the variable 'elevator.Use'
            if (playerScript != null && playerScript.elevatorUse && (playerScript.elevatorToBeUsed == gameObject.name))
            {
                Debug.LogError("elevatrtorororororo");
                MapController image = gameO.GetComponent<MapController>();
                image.ChangeFloors(playerScript.floorchangerelevator);
                message = playerScript.axis;
                playerScript.elevatorUse = false;
                StartCoroutine(ElevatorRide(playerScript, playerScript.level));
            }
        }
    }


    /*The function below handles all the teleportation events of an elevator transportation*/
    private IEnumerator ElevatorRide(WaypointSystem playerScript, int level)
    {
        TextMeshProUGUI textComponent = journeyMessage.GetComponentInChildren<TextMeshProUGUI>();
        bool is_language_visible;
        bool tog1 = false;
        bool tog2 = false;

        textComponent.text = message;
        if (exitPoints.Length > 0)
        {
            Debug.Log("Elevator moving...");
            bool is_it_paused = false;
            ItemCollector itemCollectorScript = gameO.GetComponent<ItemCollector>();
            if (!itemCollectorScript.IsPaused)
            {
                is_it_paused = true;
                itemCollectorScript.Pause_Play();
                yield return new WaitForSeconds(0.5f);
            }
            //The elevator travel message panel appears
            journeyMessage.gameObject.SetActive(true);
            if (playerScript.mobileusage == false)
            {
                movement_items.SetActive(false);
            }
            //The elevator travel sound starts playing
            AudioSource.PlayClipAtPoint(travel, Vector3.zero);
            yield return new WaitForSeconds(1f);

            //Since the navigation to a destination, when it needs a floor change and elevator usage is selected, it firstly points to an elavator
            //Therefore, we cancel the original navigation to the elevator and we turn it on later
            NavMeshAgent agent = player.GetComponent<NavMeshAgent>();
            playerScript.CancelNavigation();
            if (playerScript.destinationModeToggle.gameObject.activeSelf)
            {
                tog1 = true;
            }
            toggle1.SetActive(false);
            if (playerScript.togglerpanel.GetComponent<Toggle>().gameObject.activeSelf)
            {
                tog2 = true;
            }
            toggle2.SetActive(false);
            is_language_visible = playerScript.Flags.activeSelf;
            languages.SetActive(false);
            agent.enabled = false;
            // Move player and update rotation
            playerScript.elevatorUse = false;
            if (agent != null)
            {
                agent.enabled = true;

                //The navmesh is reset to allow for a new navigation from the new player's position
                agent.Warp(exitPoints[level].position); // Correct NavMesh position
                agent.ResetPath(); // Clear old path
                agent.velocity = Vector3.zero;  // Stop any momentum
                agent.isStopped = false;
            }

            //We teleport the player to the new floor
            player.transform.position = exitPoints[level].position;
            player.transform.rotation = exitPoints[level].rotation;

            Debug.Log("Player teleported to: " + exitPoints[level].position + " with rotation: " + exitPoints[level].rotation);

            yield return new WaitForSeconds(0.1f);

            // Now set the new destination
            // playerScript.elevatorChecker = true;

            //And we set the target to the clicked destination using the variable 'elevatorFinalTarget' which has saved the originally 
            //picked target, in the WaypointSystem script
            playerScript.SetTarget(playerScript.elevatorFinalTarget);
            playerScript.languages = is_language_visible;
            if (tog1)
            {
                playerScript.Tog1switcher = true;
            }
            toggle1.SetActive(false);
            if (tog2)
            {
                playerScript.Tog2switcher = true;
            }
            yield return new WaitForSeconds(1.35f);
            if (playerScript.mobileusage == false)
            {
                movement_items.SetActive(true);
            }
            //The travel message panel is closed
            journeyMessage.gameObject.SetActive(false);
            // movement_items.SetActive(false);
            // yield return new WaitForSeconds(1.0f);
            // audioSource.clip = mySound;
            // audioSource.pitch = 1.0f;
            // audioSource.Play();

            //An elevator arrival sound is played
            AudioSource.PlayClipAtPoint(ding, Vector3.zero);
            yield return new WaitForSeconds(1.75f);
            if (is_it_paused == true)
            {
                itemCollectorScript.Pause_Play();
            }
        }
    }
}
