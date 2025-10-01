
/*This function handles the reading and assigning of the door names that float in front of the doors, from a online repository*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class ExcelToCanvas : MonoBehaviour
{
    // ✅ PUBLIC REPOSITORY URL (No authentication needed)
    private string githubRawUrl = "https://raw.githubusercontent.com/AlviRC/Thesis/refs/heads/main/Excel%20Files/DoorNames.csv";

    /* 
    ❌ PRIVATE REPOSITORY (For Future Use)
    private string githubToken;
    private string githubRawUrl = "https://raw.githubusercontent.com/YOUR_USERNAME/YOUR_PRIVATE_REPO/main/NamesExcel.csv";
    */

    void Start()
    {
        // If using a private repo in the future, uncomment this:
        // githubToken = System.Environment.GetEnvironmentVariable("GITHUB_PAT");

        StartCoroutine(DownloadCSV());
    }

    IEnumerator DownloadCSV()
    {
        Debug.Log("Downloading CSV from GitHub...");

        UnityWebRequest request = UnityWebRequest.Get(githubRawUrl);

        /* 
        ❌ PRIVATE REPOSITORY: Add authentication if needed in the future
        request.SetRequestHeader("Authorization", "token " + githubToken);
        */

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to download CSV: " + request.error);
        }
        else
        {
            string csvData = request.downloadHandler.text;
            ProcessCSV(csvData);
        }
    }

    void ProcessCSV(string csvText)
    {
        Debug.Log("Processing CSV data...");

        string[] allLines = csvText.Split('\n');
        int lineIndex = 0;

        foreach (string line in allLines)
        {
            lineIndex++;
            if (lineIndex <= 21) continue; // Ignore first 21 lines
            if (string.IsNullOrEmpty(line)) continue;

            // Use quoted-aware CSV parser here instead of line.Split(',')
            string[] entries = ParseCsvLineSimple(line);

            if (entries.Length < 4)
            {
                Debug.LogWarning("Skipping invalid line: " + line);
                continue;
            }

            string canvasName = entries[0].Trim();
            string nameText = entries[1].Trim();
            string detailsText = entries[2].Trim();
            string extraInfoText = entries[3].Trim();

            Canvas canvas = GameObject.Find(canvasName)?.GetComponent<Canvas>();

            if (canvas != null)
            {
                TextMeshProUGUI nameTextMesh = canvas.transform.Find("Name")?.GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI detailsTextMesh = canvas.transform.Find("Details")?.GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI extraInfoTextMesh = canvas.transform.Find("Extra Info")?.GetComponent<TextMeshProUGUI>();

                if (nameTextMesh != null) nameTextMesh.text = nameText;
                if (detailsTextMesh != null) detailsTextMesh.text = detailsText;
                if (extraInfoTextMesh != null) extraInfoTextMesh.text = extraInfoText;

                canvas.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Canvas not found with name: " + canvasName);
            }
        }
    }

    // Quoted-aware CSV line parser (same as before)
    string[] ParseCsvLineSimple(string line)
    {
        List<string> fields = new List<string>();
        var current = new System.Text.StringBuilder();
        bool insideQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (c == '"')
            {
                if (insideQuotes && i + 1 < line.Length && line[i + 1] == '"')
                {
                    current.Append('"'); // Escaped quote
                    i++; // Skip next quote
                }
                else
                {
                    insideQuotes = !insideQuotes; // Toggle quoted state
                }
            }
            else if (c == ',' && !insideQuotes)
            {
                fields.Add(current.ToString());
                current.Clear();
            }
            else
            {
                current.Append(c);
            }
        }

        fields.Add(current.ToString());

        // Remove wrapping quotes if present
        for (int i = 0; i < fields.Count; i++)
        {
            string f = fields[i];
            if (f.StartsWith("\"") && f.EndsWith("\"") && f.Length >= 2)
            {
                f = f.Substring(1, f.Length - 2);
            }
            fields[i] = f;
        }

        return fields.ToArray();
    }




    // void ProcessCSV(string csvText)
    // {
    //     Debug.Log("Processing CSV data...");

    //     string[] allLines = csvText.Split('\n');
    //     int lineIndex = 0;

    //     foreach (string line in allLines)
    //     {
    //         lineIndex++;
    //         if (lineIndex <= 21) continue; // Ignore first 21 lines
    //         if (string.IsNullOrEmpty(line)) continue;

    //         string[] entries = line.Split(',');

    //         if (entries.Length < 4)
    //         {
    //             Debug.LogWarning("Skipping invalid line: " + line);
    //             continue;
    //         }

    //         string canvasName = entries[0].Trim();
    //         string nameText = entries[1].Trim();
    //         string detailsText = entries[2].Trim();
    //         string extraInfoText = entries[3].Trim();

    //         Canvas canvas = GameObject.Find(canvasName)?.GetComponent<Canvas>();

    //         if (canvas != null)
    //         {
    //             TextMeshProUGUI nameTextMesh = canvas.transform.Find("Name")?.GetComponent<TextMeshProUGUI>();
    //             TextMeshProUGUI detailsTextMesh = canvas.transform.Find("Details")?.GetComponent<TextMeshProUGUI>();
    //             TextMeshProUGUI extraInfoTextMesh = canvas.transform.Find("Extra Info")?.GetComponent<TextMeshProUGUI>();

    //             if (nameTextMesh != null) nameTextMesh.text = nameText;
    //             if (detailsTextMesh != null) detailsTextMesh.text = detailsText;
    //             if (extraInfoTextMesh != null) extraInfoTextMesh.text = extraInfoText;

    //             canvas.gameObject.SetActive(false);
    //         }
    //         else
    //         {
    //             Debug.LogWarning("Canvas not found with name: " + canvasName);
    //         }
    //     }
    // }
}