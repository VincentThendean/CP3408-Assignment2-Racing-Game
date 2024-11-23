using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class FinishSceneManager : MonoBehaviour
{
    public TextMeshProUGUI resultsText; // Updated to TextMeshProUGUI type

    void Start()
    {
        if (RaceResults.results != null && RaceResults.results.Count > 0)
        {
            resultsText.text = "Race Results:\n";
            foreach (string result in RaceResults.results)
            {
                resultsText.text += result + "\n";
            }
        }
        else
        {
            resultsText.text = "No race results available.";
        }
    }
}

