
/*This code handles the changing of the minimap image when a user changes floors*/
using UnityEngine;

public class FloorChanger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int floor;
    public GameObject mapGameObject;

    /*The function below is called when a user collides with certain gameobjects put in
    specific places where floors are ideally changed, that when triggered, the image of the minimap is changed 
    to our new floor. It calls another function, the 'ChangeFloors()' function in the 'MapController' script 
    that does the actual work.*/
    private void OnTriggerStay(Collider other)
    {
        MapController image = mapGameObject.GetComponent<MapController>();
        image.ChangeFloors(floor);
    }
}
