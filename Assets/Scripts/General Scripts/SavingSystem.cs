using System.IO;
using UnityEngine;

public class SavingSystem : MonoBehaviour
{
    public MainSystemScript MainSystemScript;
    public AudioMain AudioMain;
    public static string fileName = "SaveFile.txt";
    public int CurrentNightSaved;
    public bool IsMuted;

    public static string buildFolderPath = Path.GetDirectoryName(Application.dataPath);
    public static string path = Path.Combine(buildFolderPath, fileName);

    public void SaveNight()
    {
        // Combine both Night and IsMuted into the save file
        string content = "Night: " + CurrentNightSaved.ToString() + "\nIs Muted: " + IsMuted.ToString();
        File.WriteAllText(path, content);
        Debug.Log("File saved to: " + path);
    }

    public void LoadNight()
    {
        if (File.Exists(path))
        {
            string content = File.ReadAllText(path);
            string[] lines = content.Split('\n');

            // Validate and parse the "Night" line
            if (lines.Length > 0 && lines[0].StartsWith("Night: "))
            {
                string nightValue = lines[0].Substring(7); // Extract the value after "Night: "
                if (int.TryParse(nightValue, out int loadedNight))
                {
                    CurrentNightSaved = loadedNight;
                    MainSystemScript.CurrentNight = CurrentNightSaved;
                    Debug.Log("Night loaded successfully! Current night: " + CurrentNightSaved);
                }
                else
                {
                    Debug.LogWarning("Invalid night data in save file. Resetting to default.");
                    ResetToDefaultNight();
                    return;
                }
            }

            // Validate and parse the "Is Muted" line
            if (lines.Length > 1 && lines[1].StartsWith("Is Muted: "))
            {
                string isMutedValue = lines[1].Substring(10); // Extract the value after "Is Muted: "
                if (bool.TryParse(isMutedValue, out bool loadedIsMuted))
                {
                    IsMuted = loadedIsMuted;
                    AudioMain.IsMuted = IsMuted;
                    Debug.Log("Is Muted loaded successfully! Is Muted: " + IsMuted);
                }
                else
                {
                    Debug.LogWarning("Invalid Is Muted data in save file. Resetting to default.");
                    ResetToDefaultNight();
                    return;
                }
            }
        }
        else
        {
            Debug.LogWarning("Save file not found. Starting with default Night.");
            ResetToDefaultNight();
        }
    }

    private void ResetToDefaultNight()
    {
        CurrentNightSaved = 1;
        IsMuted = false;
        MainSystemScript.CurrentNight = CurrentNightSaved;
        AudioMain.IsMuted = IsMuted;
    }
}