using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissedDisplay : MonoBehaviour
{
    public TextMeshProUGUI missedText;
    // Start is called before the first frame update
    void Start()
    {
        if (missedText == null)
        {
            Debug.LogError("Missed text component is not assigned in the Inspector.");
            return;
        }
        UpdateMissedText(0);
    }

    // Update is called once per frame
    public void UpdateMissedText(int count){
        missedText.text = "Missed: " + count.ToString();
    }
   
}
