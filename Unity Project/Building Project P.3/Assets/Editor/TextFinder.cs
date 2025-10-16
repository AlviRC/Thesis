using UnityEngine;
using UnityEditor;
using TMPro;

public class TextFinderWindow : EditorWindow
{
    string searchText = "";

    [MenuItem("Tools/Find GameObject With Text")]
    public static void ShowWindow()
    {
        GetWindow<TextFinderWindow>("Find by Text");
    }

    void OnGUI()
    {
        GUILayout.Label("Find GameObject by Text", EditorStyles.boldLabel);
        searchText = EditorGUILayout.TextField("Search Text:", searchText);

        if (GUILayout.Button("Find"))
        {
            FindObjectsWithText(searchText);
        }
    }

    void FindObjectsWithText(string target)
    {
        if (string.IsNullOrEmpty(target)) return;

        // TextMeshProUGUI
        foreach (var tmp in Resources.FindObjectsOfTypeAll<TextMeshProUGUI>())
        {
            if (tmp.text.Contains(target))
            {
                Debug.Log($"Found TMP Text: '{tmp.text}' on {tmp.gameObject.name}", tmp.gameObject);
                EditorGUIUtility.PingObject(tmp.gameObject);
            }
        }

        // Legacy UI Text
        foreach (var txt in Resources.FindObjectsOfTypeAll<UnityEngine.UI.Text>())
        {
            if (txt.text.Contains(target))
            {
                Debug.Log($"Found UI Text: '{txt.text}' on {txt.gameObject.name}", txt.gameObject);
                EditorGUIUtility.PingObject(txt.gameObject);
            }
        }

        // 3D TextMesh
        foreach (var tm in Resources.FindObjectsOfTypeAll<TextMesh>())
        {
            if (tm.text.Contains(target))
            {
                Debug.Log($"Found TextMesh: '{tm.text}' on {tm.gameObject.name}", tm.gameObject);
                EditorGUIUtility.PingObject(tm.gameObject);
            }
        }
    }
}
