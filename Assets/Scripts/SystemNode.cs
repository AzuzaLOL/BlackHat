using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SystemNode : MonoBehaviour
{
    // Node Stats
    public string nodeName;
    public int firewall = 1;
    public int encryption = 1;
    public int reward = 5;

    // Node Progress
    public bool breached = false;
    public bool extracted = false;
    

    public GameObject selectedIcon;
    public bool isRoot = false;

    public TMP_Text nameText;
    public Image icon;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (isRoot)
        {
            nodeName = "root";
        }
        else
        {
            nodeName = "system_" + GameManager.SystemID;
            GameManager.SystemID++;
        }
        nameText.color = "orange";
        icon.color = "orange";
        nameText.text = nodeName;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RegenerateNode()
    {
        Awake();
    }

    public void Select()
    {
        selectedIcon.SetActive(true);
    }

    public void Deselect()
    {
        selectedIcon.SetActive(false);
    }

    public void Extract()
    {
        icon.color = "#7cff73";
        nameText.color = "#7cff73";
    }

    public void Bypass()
    {
        icon.color = "#ff00ffff";
        nameText.color = "#ff00ffff";
    }


}
