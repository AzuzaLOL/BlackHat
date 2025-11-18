using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Typing : MonoBehaviour
{
    public TMP_Text terminalDisplay;
    private string currentInput = "";
    private string prompt = "> ";

    public Terminal terminal;
    public InfoPanel infoPanel;

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

        // Call command processing logic here
        ProcessCommand(command);

        // Clear input after submission
        currentInput = "";
        terminalDisplay.text = prompt;
    }

    void ProcessCommand(string input)
    {
        // Handle the command
        Debug.Log("Submitted command: " + input);

        var splitInput = input.Split(" ");

        // Check command
        if (splitInput[0] == "search")
        {
            Debug.Log("Regenerating Nodes...");
            terminal.RegenerateNodes();
        }
        else if (splitInput[0] == "target")
        {
            Debug.Log("Targeting...");

            // Target Root
            if (splitInput[1] == "root")
            {
                infoPanel.SelectNode(terminal.root.GetComponent<SystemNode>());
            }
            // Target other nodes
            else
            {
                for (int i = 0; i < terminal.nodes.Length; i++)
                {
                    SystemNode node = terminal.nodes[i].GetComponent<SystemNode>();
                    if (node.nodeName == splitInput[1])
                    {
                        infoPanel.SelectNode(node);
                        break;
                    }
                }
            }
        }
        else if (splitInput[0] == "bypass")
        {
            // Do not bypass if the node is already breached
            if (infoPanel.selectedNode.breached)
            {
                Debug.Log("Bypass failed. Node already breached!");
            }
            else
            {
                Debug.Log("Bypassing...");
                infoPanel.selectedNode.breached = true;
                infoPanel.UpdateInfo();
            }
            
        }
        else if (splitInput[0] == "extract")
        {
            // Do not exctrat if node hasnt been breached yet
            if (!infoPanel.selectedNode.breached)
            {
                Debug.Log("Exctraction failed. Node not breached!");
            }
            // Do not exctract if the node was already exctracted
            else if (infoPanel.selectedNode.extracted)
            {
                Debug.Log("Exctraction failed. Node already extracted!");
            }
            else
            {
                Debug.Log("Extracting...");
                infoPanel.selectedNode.extracted = true;
                infoPanel.UpdateInfo();
            }
        }
        else
        {
            Debug.Log("Command not found");
        }
        
    }
}
