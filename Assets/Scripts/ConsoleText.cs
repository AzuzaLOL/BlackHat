using UnityEngine;
using TMPro;

public class ConsoleText : MonoBehaviour
{

    TMP_Text textObj;
    private int lineCounter = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textObj = GetComponent<TMP_Text>();
        textObj.text = "<color=#00ffffff>-----Terminal V1.0.0 Online------</color>\n";
        lineCounter += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddText(string color, string text) {
        textObj.text += "<color=" + color + ">" + text + "</color>\n";
        

        if (lineCounter > 20)
        {
            DeleteFirstLine();
        }
        else
        {
            lineCounter += 1;
        }
    }

    public void AddText(string text) {
        textObj.text += text + "\n";
        lineCounter += 1;

        if (lineCounter > 20)
        {
            DeleteFirstLine();
        }
        else
        {
            lineCounter += 1;
        }
    }

    public void DeleteFirstLine() {
        string currentText = textObj.text;
        int firstNewLine = currentText.IndexOf('\n');
        
        if (firstNewLine >= 0) {
            // Remove from start to the first newline (+1 to include the \n itself)
            textObj.text = currentText.Remove(0, firstNewLine + 1);
        }
    }
}
