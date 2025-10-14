/*This script handles the opening of url links in our program*/
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    public string url = "https://www.google.com";

    public void Open()
    {
        Application.OpenURL(url);
    }
}
