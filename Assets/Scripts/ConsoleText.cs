using UnityEngine;
using TMPro;

public class ConsoleText : MonoBehaviour
{

    TMP_Text textObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textObj = GetComponent<TMP_Text>();
        textObj.text = "<color=#00ffffff>-----Terminal V1.0.0 Online------</color>\n";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddText(string color, string text) {
        textObj.text += "<color=" + color + ">" + text + "</color>\n";
    }

    public void AddText(string text) {
        textObj.text += text + "\n";
    }
}
