
/*This script handles the e-mail option on the Professors menu. In the teacher's menu, users are given the ability to
click the professors' e-mail and immediately copy it, if a user chooses to do so.*/
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Text.RegularExpressions;
#if UNITY_WEBGL && !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

public class CopyOnClick : MonoBehaviour, IPointerClickHandler
{
    public TMP_InputField inputField;
    public GameObject copiedLabel; // Assign a Text or TMP_Text GameObject in the Inspector

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void CopyToClipboard(string str);
    #endif

    /*The function below handles the copying of the e-mail, by copying it to the user's buffer.*/
    public void OnPointerClick(PointerEventData eventData)
{
    string email = ExtractEmail(inputField.text);

    #if UNITY_WEBGL && !UNITY_EDITOR
        CopyToClipboard(email);
    #else
        GUIUtility.systemCopyBuffer = email;
    #endif
    
    if (copiedLabel != null)
    {
        copiedLabel.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(HideCopiedLabel());
    }
}


    /*The Coroutine below handles the 'Copied' message shown to the user after clicking 
    and copying the e-mail of a professor.*/
    private IEnumerator HideCopiedLabel()
    {
        yield return new WaitForSeconds(1.5f);
        copiedLabel.SetActive(false);
    }

    public static string ExtractEmail(string input)
    {
        // Match what's inside the <link> tag
        Match match = Regex.Match(input, @"<link=.*?>(.*?)</link>");
        if (match.Success)
        {
            return match.Groups[1].Value;
        }

        // If no match, fall back to stripping tags and returning raw text
        return StripRichTextTags(input);
    }

    // Optional: Strip all TMP rich text tags (for fallback or general use)
    public static string StripRichTextTags(string input)
    {
        return Regex.Replace(input, "<.*?>", string.Empty);
    }
}
