using UnityEngine;
using TMPro;

public class SystemNode : MonoBehaviour
{
    public string nodeName;
    public int firewall = 1;
    public int reward = 5;
    public GameObject selectedIcon;
    public bool isRoot = false;

    public TMP_Text nameText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (isRoot)
        {
            nodeName = "Root";
        }
        else
        {
            nodeName = "System_" + GameManager.SystemID;
            GameManager.SystemID++;
        }
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
}
