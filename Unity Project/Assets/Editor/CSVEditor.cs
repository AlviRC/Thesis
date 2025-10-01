using UnityEditor;
using UnityEngine;
using System.IO;
using System.Text;

public class CSVEditor : EditorWindow
{
    private string csvFilePath = "Assets/NamesExcel.csv";
    private string[] allLines;
    private Vector2 scrollPosition;

    // New variables for adding new rows
    private string newKey = "";
    private string newRoomName = "";
    private string newDetails = "";
    private string newExtraInfo = "";

    // Add menu item to open the editor window
    [MenuItem("Tools/CSV Editor")]
    public static void ShowWindow()
    {
        GetWindow<CSVEditor>("CSV Editor");
    }

    void OnGUI()
    {
        GUILayout.Label("CSV File Editor", EditorStyles.boldLabel);

        // Button to load the CSV
        if (GUILayout.Button("Load CSV"))
        {
            LoadCSV();
        }

        if (allLines != null)
        {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);

            // Display editable text fields for each line in the CSV
            for (int i = 0; i < allLines.Length; i++)
            {
                string line = allLines[i];
                string[] entries = line.Split(';');

                if (entries.Length == 4)
                {
                    entries[0] = EditorGUILayout.TextField("Key (e.g., H202)", entries[0]);
                    entries[1] = EditorGUILayout.TextField("Room Name", entries[1]);
                    entries[2] = EditorGUILayout.TextField("Details", entries[2]);
                    entries[3] = EditorGUILayout.TextField("Extra Info", entries[3]);

                    allLines[i] = $"{entries[0]};{entries[1]};{entries[2]};{entries[3]}";
                }
                else
                {
                    GUILayout.Label($"Invalid CSV format in line {i + 1}");
                }
            }

            GUILayout.EndScrollView();

            // Button to save the changes back to the CSV file
            if (GUILayout.Button("Save CSV"))
            {
                SaveCSV();
            }

            // Adding a new row
            GUILayout.Space(10);
            GUILayout.Label("Add New Row", EditorStyles.boldLabel);

            newKey = EditorGUILayout.TextField("Key (e.g., H202)", newKey);
            newRoomName = EditorGUILayout.TextField("Room Name", newRoomName);
            newDetails = EditorGUILayout.TextField("Details", newDetails);
            newExtraInfo = EditorGUILayout.TextField("Extra Info", newExtraInfo);

            if (GUILayout.Button("Add New Row"))
            {
                AddNewRow();
            }
        }
    }

    // Load the CSV file
    private void LoadCSV()
    {
        if (File.Exists(csvFilePath))
        {
            allLines = File.ReadAllLines(csvFilePath, Encoding.UTF8);
        }
        else
        {
            Debug.LogError("CSV file not found at " + csvFilePath);
        }
    }

    // Save the edited CSV file
    private void SaveCSV()
    {
        if (allLines != null)
        {
            File.WriteAllLines(csvFilePath, allLines, Encoding.UTF8);
            AssetDatabase.Refresh();
            Debug.Log("CSV file saved!");
        }
        else
        {
            Debug.LogError("No data to save!");
        }
    }

    // Add a new row to the CSV
    private void AddNewRow()
    {
        if (string.IsNullOrEmpty(newKey) || string.IsNullOrEmpty(newRoomName) || string.IsNullOrEmpty(newDetails) || string.IsNullOrEmpty(newExtraInfo))
        {
            Debug.LogError("All fields must be filled out to add a new row!");
            return;
        }

        // Create the new CSV row with the Key
        string newRow = $"{newKey};{newRoomName};{newDetails};{newExtraInfo}";

        // Add the new row to the allLines array
        var newLines = new string[allLines.Length + 1];
        allLines.CopyTo(newLines, 0);
        newLines[allLines.Length] = newRow;

        allLines = newLines;

        // Clear the input fields for the next row
        newKey = "";
        newRoomName = "";
        newDetails = "";
        newExtraInfo = "";

        Debug.Log("New row added!");
    }
}
