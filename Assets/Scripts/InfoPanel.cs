using UnityEngine;
using TMPro;
public class InfoPanel : MonoBehaviour
{
    public SystemNode selectedNode;
    public TMP_Text infoText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SelectNode(selectedNode);
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

    public void SelectNode(SystemNode node)
    {
        selectedNode.Deselect();
        selectedNode = node;
        selectedNode.Select();
        SetInfo(selectedNode);
    }
}
