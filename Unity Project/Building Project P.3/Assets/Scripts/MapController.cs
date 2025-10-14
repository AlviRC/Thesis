/*This script handles the handling of the minimaps in the program*/
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MapController : MonoBehaviour
{

    public GameObject mapImage;     // The full map UI image
    public GameObject bigMap;
    public GameObject MenuMap;
    public RectTransform marker;     // UI marker on the map
    public RectTransform bigMarker;
    public RectTransform MenuMarker;
    public GameObject player;         // Player in world space
    public Transform mapOrigin;      // The world-space origin reference point
    public float mapScale = 1f;      // How many UI pixels per world unit

    private Vector2 mapStartPosition;
    private Vector2 bigMarkerStartPosition;
    private Vector2 MenuMarkerStartPosition;
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public Sprite ImageFloor3;
    public Sprite ImageFloor2;
    public Sprite ImageFloor1;
    public TMP_Text FloorMessage;
    private int isFloor = 2;
    private int ismenuFloor = 2;


    /*'Start()' saves the initial positions of the 3 minimaps at start, before anything else starts to happen*/
    void Start()
    {

        //Firstly, we save the normal minimap's, the one the player sees when moving, position. We save the images start position,
        //and not the marker's position because, in this minimap, the images is the one moving and not the marker
        mapStartPosition = mapImage.GetComponent<RectTransform>().anchoredPosition;

        //Secondly, we save the maximized minimap marker's position
        bigMarkerStartPosition = bigMarker.anchoredPosition;

        //Thirdly, we save the menu minimap marker's position
        MenuMarkerStartPosition = MenuMarker.anchoredPosition;

    }

    /*'Update()' updates the position of all the three minimap markers based on the playre's position at every frame, 
    using 'UpdateMarkerPosition()'*/
    void Update()
    {
        UpdateMarkerPosition();
    }

    /*This function does all the calculations to see where each marker of each of the three minimaps should be after every frame
    and changes their values*/
    void UpdateMarkerPosition()
    {

        /*Normal mini map:*/

        //Calculates the difference between the player's position and the mapOrigin's position
        Vector3 worldOffset = player.GetComponent<Transform>().position - mapOrigin.position;

        //Takes the numbers calculated above and calculates their dimension the map's scale to get the corrct values for the UI map
        Vector2 uiOffset = new Vector2(worldOffset.x, worldOffset.z) * mapScale;

        //Moves the image based on the calculations, in the opposite side, to point the marker to the correct current position
        mapImage.GetComponent<RectTransform>().anchoredPosition = mapStartPosition - uiOffset;


        /*Miximized mini map:*/

        //Calculates the difference between the player's position and the mapOrigin's position
        Vector3 worldOffset2 = player.GetComponent<Transform>().position - mapOrigin.position;

        //Takes the numbers calculated above and calculates their dimension the map's scale to get the corrct values for the UI map
        Vector2 uiOffset2 = new Vector2(worldOffset2.x, worldOffset2.z) * 13.043650977923576986848801753895f;

        //Moves the marker based on the calculations, to point the marker to the correct current position
        bigMarker.anchoredPosition = bigMarkerStartPosition + uiOffset2;


        /*Menu mini map:*/

        //Calculates the difference between the player's position and the mapOrigin's position
        Vector3 worldOffset3 = player.GetComponent<Transform>().position - mapOrigin.position;

        //Takes the numbers calculated above and calculates their dimension the map's scale to get the corrct values for the UI map
        Vector2 uiOffset3 = new Vector2(worldOffset3.x, worldOffset3.z) * 8.061824040975778f;

        //Moves the marker based on the calculations, to point the marker to the correct current position
        MenuMarker.anchoredPosition = MenuMarkerStartPosition + uiOffset3;
    }

    /*This function changes the menu mini map to the corresponding floor*/
    public void ChangeMinimapFloor(int floor)
    {
        if (ismenuFloor != floor)
        {
            if (floor == 1)
            {
                MenuMap.GetComponent<RectTransform>().GetComponent<Image>().sprite = ImageFloor1;
                ismenuFloor = 1;
            }
            if (floor == 2)
            {
                MenuMap.GetComponent<RectTransform>().GetComponent<Image>().sprite = ImageFloor2;
                ismenuFloor = 2;
            }
            if (floor == 3)
            {
                MenuMap.GetComponent<RectTransform>().GetComponent<Image>().sprite = ImageFloor3;
                ismenuFloor = 3;
            }
        }
    }

    /*This function changes the image of the normal gameplay minimap and the maximized minimap when a floor is changed, 
    zto the corresponding floor's map*/
    public void ChangeFloors(int floor)
    {
        if (isFloor != floor)
        {
            WaypointSystem changingPanel = player.GetComponent<WaypointSystem>();
            if (floor == 1)
            {
                mapImage.GetComponent<RectTransform>().GetComponent<Image>().sprite = ImageFloor1;
                bigMap.GetComponent<RectTransform>().GetComponent<Image>().sprite = ImageFloor1;
                isFloor = 1;
                changingPanel.bigMapminiPanelDestinations = Panel2;
            }
            if (floor == 2)
            {
                mapImage.GetComponent<RectTransform>().GetComponent<Image>().sprite = ImageFloor2;
                bigMap.GetComponent<RectTransform>().GetComponent<Image>().sprite = ImageFloor2;
                isFloor = 2;
                changingPanel.bigMapminiPanelDestinations = Panel1;
            }
            if (floor == 3)
            {
                mapImage.GetComponent<RectTransform>().GetComponent<Image>().sprite = ImageFloor3;
                bigMap.GetComponent<RectTransform>().GetComponent<Image>().sprite = ImageFloor3;
                isFloor = 3;
                changingPanel.bigMapminiPanelDestinations = Panel3;
            }
        }
    }

    /*This functio changes the label of the menu floor panel above the menu minimaps that tells where the user is now compared to 
    the menu that they are looking at*/
    public void MenuMinimapHandling(int menuFloor)
    {
        //This condition checks whether the user is at the same floor as the rooms in the menu they're looking at
        if (isFloor == menuFloor)
        {
            FloorMessage.text = "	         <b>Floor " + isFloor + "</b>,  <i><u>Same/ \nΊδιο </u></i>level /επίπεδο, at         .";
        }

        //This condition checks whether the user is 1 floor below the rooms in the menu they're looking at
        else if ((menuFloor > isFloor) && (Math.Abs(menuFloor - isFloor) == 1))
        {
            FloorMessage.text = "	         <b>Floor " + isFloor + "</b>,  <i><u>1</u></i>  level/ \nεπίπεδο <u> \"↓\" </u> <i> below </i> the </i>     .";
        }

        //This condition checks whether the user is 2 floor below the rooms in the menu they're looking at
        else if ((menuFloor > isFloor) && (Math.Abs(menuFloor - isFloor) == 2))
        {
            FloorMessage.text = "	         <b>Floor " + isFloor + "</b>,  <i><u>2</u></i>  levels/ \nεπίπεδα <u> \"↓\" </u> <i> below </i> the </i>     .";
        }

        //This condition checks whether the user is 1 floor above the rooms in the menu they're looking at
        else if ((menuFloor < isFloor) && (Math.Abs(menuFloor - isFloor) == 1))
        {
            FloorMessage.text = "	         <b>Floor " + isFloor + "</b>,  <i><u>1</u></i>  level/ \nεπίπεδο <u> \"↑\" </u> <i> above </i> the </i>     .";
        }

        //This condition checks whether the user is 2 floor above the rooms in the menu they're looking at
        else if ((menuFloor < isFloor) && (Math.Abs(menuFloor - isFloor) == 2))
        {
            FloorMessage.text = "	         <b>Floor " + isFloor + "</b>,  <i><u>2</u></i>  levels/ \nεπίπεδα <u> \"↑\" </u> <i> above </i> the </i>     .";

        }
    }
}
