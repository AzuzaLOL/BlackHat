using UnityEngine;
using TMPro;

public class Typing : MonoBehaviour
{
    public TMP_Text terminalDisplay;
    private string currentInput = "";
    private string prompt = "> ";

    void Start()
    {
        terminalDisplay.text = prompt;
    }

    void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // Backspace
            {
                if (currentInput.Length > 0)
                    currentInput = currentInput.Substring(0, currentInput.Length - 1);
            }
            else if (c == '\n' || c == '\r') // Enter/Return
            {
                SubmitInput();
            }
            else
            {
                currentInput += c;
            }

            UpdateDisplay();
        }
    }

    void UpdateDisplay()
    {
        terminalDisplay.text = prompt + currentInput;
    }

    void SubmitInput()
    {
        string command = currentInput.Trim();

        // Call your command processing logic here
        ProcessCommand(command);

        // Clear input after submission
        currentInput = "";
        terminalDisplay.text = prompt;
    }

    void ProcessCommand(string input)
    {
        // You can handle the command however you want here.
        Debug.Log("Submitted command: " + input);
        // Example: trigger in-game actions, start timers, etc.
    }
}
