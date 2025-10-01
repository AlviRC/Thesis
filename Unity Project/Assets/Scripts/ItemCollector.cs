/*This script handles the mini game*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // This is required for TextMeshProUGUI

public class ItemCollector : MonoBehaviour
{
    public Camera playerCamera;
    public LayerMask itemLayer;
    public LayerMask itemLayer2;
    public LayerMask itemLayer3;
    public GameObject player;
    public GameObject interactionUI;
    private GameObject currentItem;
    public Transform target;
    public GameObject latestmen;
    public Sprite[] images;
    public Image ImageSpace;
    public GameObject pieceholder;
    public Image[] pieces;
    public TMP_Text TextSpace;
    public TMP_Text TextSpace2;
    public TMP_Text TextSpace3;
    public GameObject bachelor;
    public Button Playpausebutton;
    public Slider Playpausesound;
    public Image Playpauseimage;
    public Sprite[] PlayPause;
    public GameObject Playpausetext;
    public GameObject Playpausetext2;
    public GameObject ForcingPath;
    public GameObject Llabel;
    public GameObject LTutorialmessage;
    public GameObject LButton;
    public GameObject Arrow1;
    public GameObject Arrow2;
    public GameObject MuseumLink;
    public GameObject Dog;



    private int[] activatedImages = { 0, 0, 0, 0, 0, 0, 0, 0 };
    private int Collected = 0;

    private List<GameObject> collectedItems = new List<GameObject>();
    private int totalItems = 8;
    private AudioSource[] audioSource;
    public bool IsPaused = false;


    public float height = 1f;
    public bool mobileusage = false;


    void Start()
    {
        audioSource = GetComponents<AudioSource>();
        Playpausebutton.onClick.AddListener(Pause_Play);
        Playpausesound.onValueChanged.AddListener(Change_Volume);
        Playpausesound.value = audioSource[2].volume;
    }

    /*The 'Update()' function shoots raycasts continuously from the player to whatever they see and if the raycast hits an item 
    that has the tag only collectible items have, the collecting process begins*/
    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.Log("Raycast fired!");
        if (Physics.Raycast(ray, out hit, 3f, itemLayer))
        {
            Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
            currentItem = hit.collider.gameObject;

            //When the player looks at the collectible and is very close to it as well
            //a click to collect label appears on top of it
            interactionUI.SetActive(true);
            interactionUI.transform.position = hit.point + Vector3.up * 0.1f;// + Vector3.up * height;

            //The cursor becomes visible for the player to see and click the collectible to collect it
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            //If the player clicks the collectible, the function 'CollectItem()' is called to start the collecting process
            if (Input.GetMouseButtonDown(0))
            {
                CollectItem(currentItem);
            }
        }
        else if (Physics.Raycast(ray, out hit, 3f, itemLayer2))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if (Input.GetMouseButtonDown(0))
            {
                MuseumLink.GetComponent<OpenLink>().url = "https://museum.csd.uoc.gr/";
                MuseumLink.GetComponent<OpenLink>().Open();
            }
        }
        else if (Physics.Raycast(ray, out hit, 3f, itemLayer3))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if (Input.GetMouseButtonDown(0))
            {
                if (Dog.transform.localScale.x * 2f < 1f)
                {
                    Dog.transform.localScale *= 2f;
                }
            }
        }
        //When the player doesn't look at the collectible anymore, the collect label disappears, as well as the cursor
        else
        {
            interactionUI.SetActive(false);
            Cursor.visible = false;
            if (mobileusage == true)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void Pause_Play()
    {
        if (!audioSource[2]) return;

        if (IsPaused)
        {
            audioSource[2].UnPause();
            Playpauseimage.sprite = PlayPause[1];
            Playpausetext2.SetActive(false);
            Playpausetext.SetActive(true);
            // Playpausetext.text = "Pause Song";
        }
        else
        {
            audioSource[2].Pause();
            Playpauseimage.sprite = PlayPause[0];
            Playpausetext.SetActive(false);
            Playpausetext2.SetActive(true);
            // Playpausetext.text = "Play Song";
        }

        IsPaused = !IsPaused;
    }

    void Change_Volume(float volume)
    {
        if (audioSource[2])
        {
            audioSource[2].volume = volume;
        }
    }

    /*The function below handles the "animations" when an item is collected*/
    private IEnumerator ShowImages(int number)
    {
        // if (number == 1)
        // {
        bool play_sound = false;
        if (IsPaused == false)
        {
            play_sound = true;
            Pause_Play();
        }
        //The panel that shows up when an item is collected along with the messages and images that come with it 
        //are set up and turned on
        activatedImages[number - 1] = number;
        ImageSpace.sprite = images[number - 1];
        player.GetComponent<WaypointSystem>().closenavigationbutton.SetActive(false);
        if (gameObject.GetComponent<HoverImageChanger>().Language == "English")
        {
            TextSpace.text = "Piece \'" + number + "\' has been Collected!";
        }
        else
        {
            TextSpace.text = "Το κομμάτι \'" + number + "\' Συλλέγχθηκε!";
        }
        ImageSpace.gameObject.SetActive(true);
        TextSpace.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.3f);
        ImageSpace.gameObject.SetActive(false);
        TextSpace.gameObject.SetActive(false);
        pieceholder.SetActive(true);

        //The code below creates "animations" when items are collected.
        //They're not Unity animations, but animations created by enabling and disabling certain items
        //Creating an interesting viewing experience when an item is collected
        if (Collected != 0)
        {
            audioSource[0].Play();
            yield return new WaitForSeconds(0.35f);
            pieces[number - 1].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.35f);
            pieces[number - 1].gameObject.SetActive(false);
            yield return new WaitForSeconds(0.35f);
            pieces[number - 1].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.35f);
            pieces[number - 1].gameObject.SetActive(false);
            yield return new WaitForSeconds(0.35f);
            pieces[number - 1].gameObject.SetActive(true);
        }
        else
        {
            yield return new WaitForSeconds(0.35f);
            pieces[number - 1].gameObject.SetActive(true);
            audioSource[0].Play();
            // audioSource.clip = Sound1;
            // AudioSource.PlayClipAtPoint(Sound1, Vector3.zero);
        }
        Collected++;
        if (gameObject.GetComponent<HoverImageChanger>().Language == "English")
        {
            TextSpace2.text = Collected + "/8 pieces";
        }
        else
        {
            TextSpace2.text = Collected + "/8 κομμάτια";
        }
        if (Collected != 8)
        {
            yield return new WaitForSeconds(2f);

            if (play_sound == true)
            {
                Pause_Play();
            }
        }
        //The condition below happens when all items are collected
        else
        {
            yield return new WaitForSeconds(2f);
            audioSource[0].Play();
            pieces[0].gameObject.SetActive(false);
            pieces[1].gameObject.SetActive(false);
            pieces[2].gameObject.SetActive(false);
            pieces[3].gameObject.SetActive(false);
            pieces[4].gameObject.SetActive(false);
            pieces[5].gameObject.SetActive(false);
            pieces[6].gameObject.SetActive(false);
            pieces[7].gameObject.SetActive(false);
            yield return new WaitForSeconds(0.35f);
            pieces[0].gameObject.SetActive(true);
            pieces[1].gameObject.SetActive(true);
            pieces[2].gameObject.SetActive(true);
            pieces[3].gameObject.SetActive(true);
            pieces[4].gameObject.SetActive(true);
            pieces[5].gameObject.SetActive(true);
            pieces[6].gameObject.SetActive(true);
            pieces[7].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.35f);
            pieces[0].gameObject.SetActive(false);
            pieces[1].gameObject.SetActive(false);
            pieces[2].gameObject.SetActive(false);
            pieces[3].gameObject.SetActive(false);
            pieces[4].gameObject.SetActive(false);
            pieces[5].gameObject.SetActive(false);
            pieces[6].gameObject.SetActive(false);
            pieces[7].gameObject.SetActive(false);
            yield return new WaitForSeconds(0.35f);
            pieces[0].gameObject.SetActive(true);
            pieces[1].gameObject.SetActive(true);
            pieces[2].gameObject.SetActive(true);
            pieces[3].gameObject.SetActive(true);
            pieces[4].gameObject.SetActive(true);
            pieces[5].gameObject.SetActive(true);
            pieces[6].gameObject.SetActive(true);
            pieces[7].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.35f);
            pieces[0].gameObject.SetActive(false);
            pieces[1].gameObject.SetActive(false);
            pieces[2].gameObject.SetActive(false);
            pieces[3].gameObject.SetActive(false);
            pieces[4].gameObject.SetActive(false);
            pieces[5].gameObject.SetActive(false);
            pieces[6].gameObject.SetActive(false);
            pieces[7].gameObject.SetActive(false);
            yield return new WaitForSeconds(0.35f);
            if (gameObject.GetComponent<HoverImageChanger>().Language == "English")
            {
                TextSpace2.text = "All Pieces Collected! Path Unlocked...";
            }
            else
            {
                TextSpace2.text = "Όλα τα Κομμάτια έχουν Συλλεγχθεί! Το Μονοπάτι Ξεκλειδώθηκε...";
            }
            bachelor.SetActive(true);
            yield return new WaitForSeconds(2f);
            if (gameObject.GetComponent<HoverImageChanger>().Language == "English")
            {
                TextSpace2.text = "Follow it.";
            }
            else
            {
                TextSpace2.text = "Ακολούθα το.";
            }
            yield return new WaitForSeconds(1f);
            if (play_sound == true)
            {
                Pause_Play();
            }
            AllItemsCollected();
        }
        pieceholder.SetActive(false);
        // }
    }

    /*The function below handles the collection of the collectibles*/
    void CollectItem(GameObject item)
    {
        //The conditions below check which collectible the one collected was
        if (item.name == "1-min - Anagnostirio")
        {
            StartCoroutine(ShowImages(1));
        }
        if (item.name == "2-min - AMFSO")
        {
            StartCoroutine(ShowImages(2));
        }
        if (item.name == "3-min - Aithrio Outside Door")
        {
            StartCoroutine(ShowImages(3));
        }
        if (item.name == "4-min - Cafeteria")
        {
            StartCoroutine(ShowImages(4));
        }
        if (item.name == "5-min - H/K 3 Hallway")
        {
            StartCoroutine(ShowImages(5));
        }
        if (item.name == "6-min - E/B 2 Hallway")
        {
            StartCoroutine(ShowImages(6));
        }
        if (item.name == "7-min - K Steel Stairs")
        {
            StartCoroutine(ShowImages(7));
        }
        if (item.name == "8-min - Stands")
        {
            StartCoroutine(ShowImages(8));
        }

        //After the item is collected, it gets added to the collected items and its disabled
        collectedItems.Add(item);
        item.SetActive(false);

        // if (collectedItems.Count >= totalItems)
        // {
        //     AllItemsCollected();
        // }
    }
    /*The function below is called when all items are collected. It starts a navigation path to a "secret" location for a special 
    message for collecting all items*/
    void AllItemsCollected()
    {
        bachelor.SetActive(false);
        target.gameObject.SetActive(true);
        player.GetComponent<WaypointSystem>().CallToggelNavigation();
        player.GetComponent<WaypointSystem>().SetLatestMenu(Llabel);
        ForcingPath.SetActive(true);
        if (mobileusage == true)
        {
            if (player.GetComponent<WaypointSystem>().buttonOpenMinimap.activeSelf)
            {
                minimapstate = "opened";
                player.GetComponent<WaypointSystem>().buttonOpenMinimap.SetActive(false);
            }
            else
            {
                player.GetComponent<WaypointSystem>().buttonHideMinimap.SetActive(false);
                player.GetComponent<WaypointSystem>().buttonMaxMinimap.SetActive(false);
            }
        }
        player.GetComponent<WaypointSystem>().SetTarget(target);
        if (player.GetComponent<WaypointSystem>().mobileusage == true)
        {
            player.GetComponent<WaypointSystem>().closenavigationbutton.SetActive(false);
        }
        else
        {
            player.GetComponent<WaypointSystem>().XbeingAbledToUse = false;
            player.GetComponent<WaypointSystem>().cancelLabel.gameObject.SetActive(false);
        }
        Debug.LogWarning("All items collected!");
    }
    private string minimapstate = "closed";
    private IEnumerator MessageComplete()
    {
        Pause_Play();
        yield return new WaitForSeconds(0.75f);
        audioSource[1].Play();
        target.gameObject.SetActive(false);
        TextSpace2.gameObject.SetActive(false);
        TextSpace3.gameObject.SetActive(true);
        bachelor.SetActive(true);
        pieceholder.SetActive(true);
        yield return new WaitForSeconds(4f);
        bachelor.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        if (gameObject.GetComponent<HoverImageChanger>().Language == "English")
        {
            TextSpace3.text = "Unfortunately, it's fake... :(";
        }
        else
        {
            TextSpace3.text = "Δυστυχώς, είναι ψεύτικο... :(";
        }
        yield return new WaitForSeconds(2f);
        pieceholder.SetActive(false);
        if (player.GetComponent<WaypointSystem>().mobileusage == true)
        {
            player.GetComponent<WaypointSystem>().closenavigationbutton.SetActive(true);
        }
        else
        {
            player.GetComponent<WaypointSystem>().XbeingAbledToUse = true;
            player.GetComponent<WaypointSystem>().cancelLabel.gameObject.SetActive(true);
        }
        if (mobileusage == true)
        {
            LButton.SetActive(true);
            Arrow2.SetActive(true);
        }
        else
        {
            LTutorialmessage.SetActive(true);
            Arrow1.SetActive(true);
        }
        ForcingPath.SetActive(false);
        if (mobileusage == true)
        {
            if (minimapstate == "opened")
            {
                minimapstate = "closed";
                player.GetComponent<WaypointSystem>().buttonOpenMinimap.SetActive(true);
            }
            // else
            // {
            //     player.GetComponent<WaypointSystem>().buttonHideMinimap.SetActive(true);
            //     player.GetComponent<WaypointSystem>().buttonMaxMinimap.SetActive(true);
            // }
        }
        player.GetComponent<WaypointSystem>().CancelNavigation();
        player.GetComponent<WaypointSystem>().LbeingAbledToUse = true;
        player.GetComponent<WaypointSystem>().lfirstUse = true;
        // player.GetComponent<WaypointSystem>().CloseMainMenu(player.GetComponent<WaypointSystem>().MainMenuButtons);
    }
    public void GiveDegree()
    {
        StartCoroutine(MessageComplete());
    }
}
