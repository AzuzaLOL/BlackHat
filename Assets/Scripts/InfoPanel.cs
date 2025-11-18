using UnityEngine;
using TMPro;
public class InfoPanel : MonoBehaviour
{
    public SystemNode selectedNode;
    public TMP_Text nameText;
    public TMP_Text firewallText;
    public TMP_Text encryptionText;
    public TMP_Text rewardText;

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
        nameText.text = "Name: " + node.nodeName;
        firewallText.text = "Firewall:        " + node.firewall;

        if (!node.breached)
        {
            encryptionText.text = "Encryption: ???";
            rewardText.text = "Reward:     ???";
        }
        else
        {
            encryptionText.text = "Encryption: " + node.encryption;
            rewardText.text = "Reward:     " + node.reward;
        }

    }

    public void UpdateInfo()
    {
        SetInfo(selectedNode);
    }

    public void SelectNode(SystemNode node)
    {
        selectedNode.Deselect();
        selectedNode = node;
        selectedNode.Select();
        SetInfo(selectedNode);
    }
}
