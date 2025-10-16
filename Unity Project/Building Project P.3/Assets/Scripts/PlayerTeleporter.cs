/*This script handles the teleportation of the player when a teleportation destination
is picked in the teleportation menu*/
using UnityEngine;
using System.Collections;

public class PlayerTeleporter : MonoBehaviour
{
    public GameObject player;
    public bool ameateleport = false;

    /*When a teleportation destination is picked on the teleportation menu, the function below is called to
    start a coroutine to handle the teleportation.*/
    public void TeleportTo(GameObject target)
    {
        StartCoroutine(TeleportCoroutine(target));
    }

    /*The Coroutine below handles the actual teleportation of the user when a teleport destination is picked.*/
    private IEnumerator TeleportCoroutine(GameObject to)
    {

        //Waiting for one frame so there are no conflicts
        yield return null;

        //Even though the teleportation happens with buttons on the main menu, when the player's movement isnt enabled,
        //for the teleportation to happen, the movement must be enabled, so we enable it temporarily and change the player's position 
        //and rotation to the chosen item's ones and afterwards, we disable the movement again as we're still in the menu
        player.GetComponent<Movement_Player>().enabled = true;
        player.transform.position = to.transform.position;
        player.transform.rotation = to.transform.rotation;
        player.GetComponent<Movement_Player>().enabled = false;

        //Another thing that must change is the navmesh agent, to the new position, so any destination navigation that may happen can start 
        //from the new position
        WaypointSystem playerScript = player.GetComponent<WaypointSystem>();

        yield return null;
        if (playerScript.agent != null)
        {
            playerScript.agent.Warp(to.transform.position);
            playerScript.agent.ResetPath();
        }
        
        if (ameateleport == true)
        {
            ameateleport = false;
            yield return null;
            player.GetComponent<Movement_Player>().enabled = true;
        }
    }
}
