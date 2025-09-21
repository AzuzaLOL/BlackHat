using UnityEngine;
using TMPro;
public class InfoPanel : MonoBehaviour
{
    public SystemNode selectedNode;
    public TMP_Text infoText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selectedNode.Select();
        SetInfo(selectedNode);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetInfo(SystemNode node)
    {
        infoText.text = "Name: " + node.nodeName;
        infoText.text += "\nFirewall Level: " + node.firewall;
        infoText.text += "\nReward: ???"; 
    }
}
