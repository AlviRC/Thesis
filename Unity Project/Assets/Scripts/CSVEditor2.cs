using System.IO;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class CSVEditor2 : MonoBehaviour
{
    public GameObject openPanel;
    public GameObject editorPanel;
    public TMP_InputField csvInputField;
    private string filePath;
    private string lastKeys = "";
    public GameObject player;
    public GameObject Game;

    void Update()
    {
        DetectKeyCombination();
    }

    void DetectKeyCombination()
    {
        string keys = "123456789";

        foreach (char c in Input.inputString)
        {
            lastKeys += c;
            if (!keys.StartsWith(lastKeys))
            {
                lastKeys = "";
            }
            else if (lastKeys == keys)
            {
                lastKeys = "";
                Game.GetComponent<ItemCollector>().enabled = false;
                openPanel.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                player.GetComponent<Movement_Player>().enabled = false;
            }
        }
    }

    public void setString(string path)
    {
        filePath = Path.Combine(Application.persistentDataPath, path);
        OpenEditor();
    }

    void OpenEditor()
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            string formattedText = "";

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts.Length > 1)
                {
                    formattedText += $"<color=#b100cd>{parts[0]}</color>"; // First item in purple

                    for (int i = 1; i < parts.Length; i++)
                    {
                        formattedText += $"<mark=#FF0000><color=#008000>;</color></mark>{parts[i]}";
                    }
                    formattedText += "\n";
                }
                else
                {
                    formattedText += line + "\n";
                }
            }

            csvInputField.text = formattedText; // Show formatted text while editing
        }
    }

    public void SaveChanges()
    {
        // Remove formatting before saving
        string rawText = RemoveRichTextFormatting(csvInputField.text);

        string[] lines = rawText.Split('\n');
        string[] originalLines = File.ReadAllLines(filePath);
        string newCSV = "";

        for (int i = 0; i < lines.Length && i < originalLines.Length; i++)
        {
            string[] originalParts = originalLines[i].Split(';');
            string[] editedParts = lines[i].Split(';');

            if (originalParts.Length > 0 && editedParts.Length > 1)
            {
                newCSV += originalParts[0] + ";" + string.Join(";", editedParts, 1, editedParts.Length - 1) + "\n";
            }
            else
            {
                newCSV += originalLines[i] + "\n";
            }
        }

        File.WriteAllText(filePath, newCSV);
    }

    private string RemoveRichTextFormatting(string text)
    {
        string pattern = @"<\/?color[^>]*>|<\/?mark[^>]*>";
        return Regex.Replace(text, pattern, "");
    }

    public void ExitEditing()
    {
        openPanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<Movement_Player>().enabled = true;
        Game.GetComponent<ItemCollector>().enabled = true;
    }
}
