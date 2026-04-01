using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Collections.Generic;
using FMODUnity;

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
    public StudioEventEmitter targetEmitter;

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
            Search();
        }
        else if (splitInput[0] == "target")
        {
            Target(splitInput);
        }
        else if (splitInput[0] == "bypass")
        {
            Bypass();
        }
        else if (splitInput[0] == "extract")
        {
            Extract();
        }
        else
        {
            Debug.Log("Command not found");
            consoleText.AddText("red", "Error: Command not found");
        }

    }


    // Search command
    // Regenerate all nodes
    void Search()
    {
        Debug.Log("Regenerating Nodes...");
        terminal.RegenerateNodes();

        consoleText.AddText("yellow", "Searching for systems on the network...");
        consoleText.AddText("#7cff73", "System nodes found!");
    }

    // Target command
    void Target(string[] splitInput)
    {
        Debug.Log("Targeting...");
        consoleText.AddText("#ff4400", "Targeting Node...");

        // Check command format
        if (splitInput.Length != 2)
        {
            consoleText.AddText("red", "Targeting failed. Invalid command format");
            consoleText.AddText("yellow", "Command format: 'target <name>'");
            return;
        }


        // Target Root
        if (splitInput[1] == "root")
        {
            consoleText.AddText("#7cff73", "Root successfully targeted!");
            infoPanel.SelectNode(terminal.root.GetComponent<SystemNode>());

            // Audio for Targeting
            targetEmitter.Play();
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

                    // Audio for Targeting
                    targetEmitter.Play();

                    return;
                }
            }

            consoleText.AddText("red", "Targeting failed. Invalid node name");
            consoleText.AddText("yellow", "Command format: 'target <name>'");
        }
    }

    // Bypass command
    void Bypass()
    {
        Debug.Log("Bypassing...");
        consoleText.AddText("orange", "Attempting to bypass firewall...");
        // Do not bypass if the node is already breached
        if (infoPanel.selectedNode.breached)
        {
            Debug.Log("Bypass failed. Node already breached!");
            consoleText.AddText("red", "Firewall bypass failed. Node already breached!");
        }
        // Do not bypass if node was already failed
        else if (infoPanel.selectedNode.hackFailed)
        {
            Debug.Log("Bypass failed. Hack already attempted!");
            consoleText.AddText("red", "Bypass failed. Hack already attempted!");
        }
        else
        {
            // Attempt to bypass
            if (!GameManager.forceHackFail && CheckBypassSuccess())
            {
                // Bypass the node
                infoPanel.selectedNode.breached = true;
                infoPanel.UpdateInfo();
                consoleText.AddText("#7cff73", infoPanel.selectedNode.nodeName + " successfully bypassed!");
                infoPanel.selectedNode.Bypass();
            }
            else
            {
                // Hack fails
                infoPanel.selectedNode.hackFailed = true;
                // Currently no infoPanel change for a failure
                // infoPanel.UpdateInfo();
                consoleText.AddText("#ff0000ff", "Bypassing the firewall from node: " + infoPanel.selectedNode.nodeName + " failed.");
                infoPanel.selectedNode.FailHack();
            }
        }
    }

    // Attempt to bypass the node using levels
    bool CheckBypassSuccess()
    {
        // Calculate if the node is bypassed based on level difference
        // Add defaults to the result lise (default hack chances for equal levels)
        List<bool> resultList = new List<bool>();
        resultList.Add(true);
        resultList.Add(true);
        resultList.Add(false);

        // Add true for each bypass level higher than firewall
        for (int i = GameManager.bypassLevel - infoPanel.selectedNode.firewall; i > 0; i--)
        {
            resultList.Add(true);
        }

        // Add false for each firewall level higher than bypass
        for (int i = infoPanel.selectedNode.firewall - GameManager.bypassLevel; i > 0; i--)
        {
            resultList.Add(false);
        }

        // Choose if hack succeeds or not
        int chosenIndex = Random.Range(0, resultList.Count);

        return resultList[chosenIndex];
    }

    // Extract Command
    void Extract()
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
        // Do not extract if node was already failed
        else if (infoPanel.selectedNode.hackFailed)
        {
            Debug.Log("Extraction failed. Hack already attempted!");
            consoleText.AddText("red", "Extraction failed. Hack already attempted!");
        }
        else
        {
            // Attempt to extract
            if (!GameManager.forceHackFail && CheckExtractSuccess())
            {
                // Extract the node
                infoPanel.selectedNode.extracted = true;
                infoPanel.UpdateInfo();
                consoleText.AddText("#7cff73", "$" + infoPanel.selectedNode.reward + " successfully extracted from " + infoPanel.selectedNode.nodeName);
                infoPanel.selectedNode.Extract();
                balanceText.UpdateBalance();
            }
            else
            {
                // Hack fails
                infoPanel.selectedNode.hackFailed = true;
                // Currently no infoPanel change for a failure
                // infoPanel.UpdateInfo();
                consoleText.AddText("#ff0000ff", "Extraction of reward from node: " + infoPanel.selectedNode.nodeName + " failed.");
                infoPanel.selectedNode.FailHack();
            }

        }
    }
    
    bool CheckExtractSuccess()
    {
        // Calculate if the node is extracted based on level difference
        // Add defaults to the result lise (default hack chances for equal levels)
        List<bool> resultList = new List<bool>();
        resultList.Add(true);
        resultList.Add(true);
        resultList.Add(false);

        // Add true for each extract level higher than encryption
        for (int i = GameManager.extractLevel - infoPanel.selectedNode.encryption; i > 0; i--)
        {
            resultList.Add(true);
        }

        // Add false for each encryption level higher than extract
        for (int i = infoPanel.selectedNode.encryption - GameManager.extractLevel; i > 0; i--)
        {
            resultList.Add(false);
        }

        // Choose if hack succeeds or not
        int chosenIndex = Random.Range(0, resultList.Count);

        return resultList[chosenIndex];
    }


}

