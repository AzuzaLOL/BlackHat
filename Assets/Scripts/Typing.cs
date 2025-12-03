using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Typing : MonoBehaviour
{
    public TMP_Text terminalDisplay;
    private string currentInput = "";
    private string prompt = "> ";

    // For other objects
    public Terminal terminal;
    public InfoPanel infoPanel;
    public ConsoleText consoleText;
    public BalanceText balanceText;

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
        consoleText.AddText(input);

        var splitInput = input.Split(" ");

        // Check command
        if (splitInput[0] == "search")
        {
            Debug.Log("Regenerating Nodes...");
            terminal.RegenerateNodes();

            consoleText.AddText("yellow", "Searching for systems on the network...");
            consoleText.AddText("#7cff73", "System nodes found!");
        }
        else if (splitInput[0] == "target")
        {
            Debug.Log("Targeting...");
            consoleText.AddText("#ff4400", "Targeting Node...");

            // Check command format
            if (splitInput.Length != 2) {
                    consoleText.AddText("red", "Targeting failed. Invalid command format");
                    consoleText.AddText("yellow", "Command format: 'target <name>'");
                    return;
            }

        
            // Target Root
            if (splitInput[1] == "root")
            {
                consoleText.AddText("#7cff73", "Root successfully targeted!");
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
                        consoleText.AddText("#7cff73", infoPanel.selectedNode.nodeName + " successfully targeted!");
                        return;
                    }
                }

                consoleText.AddText("red", "Targeting failed. Invalid node name");
                consoleText.AddText("yellow", "Command format: 'target <name>'");
            }
        }
        else if (splitInput[0] == "bypass")
        {
            Debug.Log("Bypassing...");
            consoleText.AddText("orange", "Attempting to bypass firewall...");
            // Do not bypass if the node is already breached
            if (infoPanel.selectedNode.breached)
            {
                Debug.Log("Bypass failed. Node already breached!");
                consoleText.AddText("red", "Firewall bypass failed. Node already breached!");
            }
            else
            {
                
                infoPanel.selectedNode.breached = true;
                infoPanel.UpdateInfo();
                consoleText.AddText("#7cff73", infoPanel.selectedNode.nodeName + " successfully bypassed!");
                infoPanel.selectedNode.Bypass();
            }
            
        }
        else if (splitInput[0] == "extract")
        {
            Debug.Log("Extracting...");
            consoleText.AddText("#ff00ffff", "Attempting to extract reward...");
            // Do not exctrat if node hasnt been breached yet
            if (!infoPanel.selectedNode.breached)
            {
                Debug.Log("Exctraction failed. Node not breached!");
                consoleText.AddText("red", "Extraction failed. Node hasn't been breached!");
            }
            // Do not exctract if the node was already exctracted
            else if (infoPanel.selectedNode.extracted)
            {
                Debug.Log("Exctraction failed. Node already extracted!");
                consoleText.AddText("red", "Extraction failed. Reward already extracted!");
            }
            else
            {
                
                infoPanel.selectedNode.extracted = true;
                infoPanel.UpdateInfo();
                consoleText.AddText("#7cff73", "$" + infoPanel.selectedNode.reward + " successfully extracted from " + infoPanel.selectedNode.nodeName);
                infoPanel.selectedNode.Extract();
                balanceText.UpdateBalance();
            }
        }
        else
        {
            Debug.Log("Command not found");
            consoleText.AddText("red", "Error: Command not found");
        }
        
    }
}
