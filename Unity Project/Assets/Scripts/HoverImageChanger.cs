using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HoverImageChanger : MonoBehaviour
{
    public string[] English;
    public string[] Greek;
    public Image EnteranceImage;
    public Image AuditoriumImage;
    public Image HallwayImage;
    public Image StudyRoomImage;
    public Image OutsideImage;
    public Image Floor1Image;
    public Image Floor2Image;
    public Image Floor3Image;
    public Image MainAreasImage;

    public Sprite[] Enterances_images;
    public Sprite[] Auditorium_images;
    public Sprite[] Hallway_images;
    public Sprite[] StudyRoom_images;
    public Sprite[] Outside_images;
    public Sprite[] Floor1_images;
    public Sprite[] Floor2_images;
    public Sprite[] Floor3_images;
    public Sprite[] MainAreas_images;

    public TextMeshProUGUI[] TextFields;


    public string Language = "English";
    public Image FlagHolder;
    public Sprite[] countries;
    public GameObject LoadingScreen;
    public string buttonModes = "Colorful";
    public Image[] buttonImages;
    public Sprite[] button_sprites;
    private Color c;



    public void ChangeEnterance(int number)
    {
        // EnteranceImage.GetComponent<RectTransform>().GetComponent<Image>().sprite = Enterances_images[number];
        EnteranceImage.sprite = Enterances_images[number];
    }

    public void ChangeAuditorium(int number)
    {
        // AuditoriumImage.GetComponent<RectTransform>().GetComponent<Image>().sprite = Auditorium_images[number];
        AuditoriumImage.sprite = Auditorium_images[number];
    }

    public void ChangeHallway(int number)
    {
        // HallwayImage.GetComponent<RectTransform>().GetComponent<Image>().sprite = Hallway_images[number];
        HallwayImage.sprite = Hallway_images[number];
    }

    public void ChangeStudyRoom(int number)
    {
        // StudyRoomImage.GetComponent<RectTransform>().GetComponent<Image>().sprite = StudyRoom_images[number];
        StudyRoomImage.sprite = StudyRoom_images[number];
    }

    public void ChangeOutsideArea(int number)
    {
        // OutsideImage.GetComponent<RectTransform>().GetComponent<Image>().sprite = Outside_images[number];
        OutsideImage.sprite = Outside_images[number];
    }

    public void ChangeFloor1(int number)
    {
        // Floor1Image.GetComponent<RectTransform>().GetComponent<Image>().sprite = Floor1_images[number];
        Floor1Image.sprite = Floor1_images[number];
    }

    public void ChangeFloor2(int number)
    {
        // Floor2Image.GetComponent<RectTransform>().GetComponent<Image>().sprite = Floor2_images[number];
        Floor2Image.sprite = Floor2_images[number];
    }

    public void ChangeFloor3(int number)
    {
        // Floor3Image.GetComponent<RectTransform>().GetComponent<Image>().sprite = Floor3_images[number];
        Floor3Image.sprite = Floor3_images[number];
    }

    public void ChangeMainAreas(int number)
    {
        // MainAreasImage.GetComponent<RectTransform>().GetComponent<Image>().sprite = MainAreas_images[number];
        MainAreasImage.sprite = MainAreas_images[number];
    }

    [ContextMenu("Do Something Useful")]
    public void ChangeLanguage()
    {
        LoadingScreen.SetActive(true);
        if (Language == "English")
        {
            Language = "Greek";
            for (int i = 0; i < TextFields.Length; i++)
            {
                TextFields[i].text = Greek[i];
            }
        }
        else
        {
            Language = "English";
            for (int i = 0; i < TextFields.Length; i++)
            {
                TextFields[i].text = English[i];
            }
        }
        LoadingScreen.SetActive(false);
    }

    [ContextMenu("Szello?")]
    public void ChangeButtons()
    {
        if (buttonModes == "Colorful")
        {
            buttonModes = "None";
            for (int i = 0; i < buttonImages.Length; i++)
            {
                buttonImages[i].sprite = button_sprites[0];
                if (i == 0) //Set Destination - Main Menu
                {
                    RectTransform rt = buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().GetComponent<RectTransform>();
                    // Vector2 pos = rt.anchoredPosition;
                    rt.offsetMax = new Vector2(rt.offsetMax.x, 1f);
                    rt.offsetMin = new Vector2(rt.offsetMin.x, 1f);
                    buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 15.7f;
                }
                if (i == 2) //Courses & Teachers - Main Menu
                {
                    // c = buttonImage.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.color;
                    ColorUtility.TryParseHtmlString("#323232", out c);
                    buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = c;
                    buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 15.7f;
                }
                else if (i == 3) //Timetable - Main Menu
                {
                    ColorUtility.TryParseHtmlString("#323232", out c);
                    buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = c;
                }
                else if (i == 5) //Winter Semester - Main Destinations
                {
                    ColorUtility.TryParseHtmlString("#323232", out c);
                    buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = c;
                    // buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 15.7f;
                    RectTransform rt = buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().GetComponent<RectTransform>();
                    rt.offsetMax = new Vector2(rt.offsetMax.x, -0.4f);
                    rt.offsetMin = new Vector2(rt.offsetMin.x, 0.4f);
                }
                else if (i == 6) //Spring Semester - Main Destinations
                {
                    ColorUtility.TryParseHtmlString("#323232", out c);
                    buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = c;
                    RectTransform rt = buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().GetComponent<RectTransform>();
                    rt.offsetMax = new Vector2(rt.offsetMax.x, -0.1f);
                    rt.offsetMin = new Vector2(rt.offsetMin.x, 0.1f);

                }
                else if (i == 7) //Teacher's Offices - Main Destinations
                {
                    ColorUtility.TryParseHtmlString("#323232", out c);
                    buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = c;
                    RectTransform rt = buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().GetComponent<RectTransform>();
                    rt.offsetMax = new Vector2(rt.offsetMax.x, -0.4f);
                    rt.offsetMin = new Vector2(rt.offsetMin.x, 0.4f);
                }
                else if (i == 21)
                {
                    // ColorUtility.TryParseHtmlString("#323232", out c);
                    // buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = c;
                    RectTransform rt = buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().GetComponent<RectTransform>();
                    rt.offsetMax = new Vector2(rt.offsetMax.x, -4.1f);
                    rt.offsetMin = new Vector2(rt.offsetMin.x, 4.1f);
                }
                else if (i == 22)
                {
                    // ColorUtility.TryParseHtmlString("#323232", out c);
                    // buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = c;
                    RectTransform rt = buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().GetComponent<RectTransform>();
                    rt.offsetMax = new Vector2(rt.offsetMax.x, -6.9f);
                    rt.offsetMin = new Vector2(rt.offsetMin.x, 6.9f);
                }
                else if (i == 23)
                {
                    ColorUtility.TryParseHtmlString("#323232", out c);
                    buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = c;
                    RectTransform rt = buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().GetComponent<RectTransform>();
                    rt.offsetMax = new Vector2(rt.offsetMax.x, -5f);
                    rt.offsetMin = new Vector2(rt.offsetMin.x, 5f);
                }
                else if (i == 24)
                {
                    // ColorUtility.TryParseHtmlString("#323232", out c);
                    // buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = c;
                    RectTransform rt = buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().GetComponent<RectTransform>();
                    rt.offsetMax = new Vector2(rt.offsetMax.x, -6.9f);
                    rt.offsetMin = new Vector2(rt.offsetMin.x, 6.9f);
                    buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 13.2f;
                }
                else if (i == 25)
                {
                    // ColorUtility.TryParseHtmlString("#323232", out c);
                    // buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = c;
                    RectTransform rt = buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().GetComponent<RectTransform>();
                    rt.offsetMax = new Vector2(rt.offsetMax.x, -6.9f);
                    rt.offsetMin = new Vector2(rt.offsetMin.x, 6.9f);
                    buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 13.2f;
                }
            }
        }
        else
        {
            buttonModes = "Colorful";
            for (int i = 0; i < buttonImages.Length; i++)
            {
                buttonImages[i].sprite = button_sprites[i + 1];
                if (i == 0) //Set Destination - Main Menu
                {
                    RectTransform rt = buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().GetComponent<RectTransform>();
                    // Vector2 pos = rt.anchoredPosition;
                    // pos.y = -9.629f;
                    rt.offsetMax = new Vector2(rt.offsetMax.x, -1.200001f);
                    rt.offsetMin = new Vector2(rt.offsetMin.x, 30.2f);
                    buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 11.4f;
                }
                if (i == 2) //Courses & Teachers - Main Menu
                {
                    // c = buttonImage.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.color;
                    ColorUtility.TryParseHtmlString("#FFFFFF", out c);
                    buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = c;
                    buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 13.1f;
                }
                else if (i == 3) //Timetable - Main Menu
                {
                    ColorUtility.TryParseHtmlString("#000000", out c);
                    buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = c;
                }
                else if (i == 5) //Winter Semester - Main Destinations
                {
                    ColorUtility.TryParseHtmlString("#1B1A1A", out c);
                    buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = c;
                    RectTransform rt = buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().GetComponent<RectTransform>();
                    rt.offsetMax = new Vector2(rt.offsetMax.x, 0.5f);
                    rt.offsetMin = new Vector2(rt.offsetMin.x, 9.5f);
                }
                else if (i == 6) //Spring Semester - Main Destinations
                {
                    ColorUtility.TryParseHtmlString("#333333", out c);
                    buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = c;
                    RectTransform rt = buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().GetComponent<RectTransform>();
                    rt.offsetMax = new Vector2(rt.offsetMax.x, -1.5f);
                    rt.offsetMin = new Vector2(rt.offsetMin.x, 13.5f);
                }
                else if (i == 7) //Teacher's Offices - Main Destinations/?
                {
                    ColorUtility.TryParseHtmlString("#E5E5E5", out c);
                    buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = c;
                    RectTransform rt = buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().GetComponent<RectTransform>();
                    rt.offsetMax = new Vector2(rt.offsetMax.x, 0.5f);
                    rt.offsetMin = new Vector2(rt.offsetMin.x, 13.9f);
                }
                else if (i == 21)
                {
                    // ColorUtility.TryParseHtmlString("#323232", out c);
                    // buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = c;
                    RectTransform rt = buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().GetComponent<RectTransform>();
                    rt.offsetMax = new Vector2(rt.offsetMax.x, 1.4f);
                    rt.offsetMin = new Vector2(rt.offsetMin.x, 6.8f);
                }
                else if (i == 22)
                {
                    // ColorUtility.TryParseHtmlString("#323232", out c);
                    // buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = c;
                    RectTransform rt = buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().GetComponent<RectTransform>();
                    rt.offsetMax = new Vector2(rt.offsetMax.x, 0.8999996f);
                    rt.offsetMin = new Vector2(rt.offsetMin.x, 12.9f);
                }
                else if (i == 23)
                {
                    ColorUtility.TryParseHtmlString("#E5E5E5", out c);
                    buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = c;
                    RectTransform rt = buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().GetComponent<RectTransform>();
                    rt.offsetMax = new Vector2(rt.offsetMax.x, -1f);
                    rt.offsetMin = new Vector2(rt.offsetMin.x, 14.6f);
                }
                else if (i == 24)
                {
                    // ColorUtility.TryParseHtmlString("#323232", out c);
                    // buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = c;
                    RectTransform rt = buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().GetComponent<RectTransform>();
                    rt.offsetMax = new Vector2(rt.offsetMax.x, -0.829f);
                    rt.offsetMin = new Vector2(rt.offsetMin.x, 12.371f);
                    buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 12.6f;
                }
                else if (i == 25)
                {
                    // ColorUtility.TryParseHtmlString("#323232", out c);
                    // buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = c;
                    RectTransform rt = buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().GetComponent<RectTransform>();
                    rt.offsetMax = new Vector2(rt.offsetMax.x, 0.4999995f);
                    rt.offsetMin = new Vector2(rt.offsetMin.x, 12.7f);
                    buttonImages[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontSize = 12.6f;
                }
            }
        }

    }

}
