using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SystemNode : MonoBehaviour
{
    // Node Stats
    public string nodeName;
    public int firewall = 1;
    public int encryption = 1;
    public int reward;

    // Node Progress
    public bool breached = false;
    public bool extracted = false;
    

    // Visuals
    public GameObject selectedIcon;
    public bool isRoot = false;

    public TMP_Text nameText;

    public Sprite[] possibleIcons;
    public Image icon;

    public ParticleSystem ps;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        ps = GetComponent<ParticleSystem>();

        // Update Name
        if (isRoot)
        {
            nodeName = "root";
        }
        else
        {
            nodeName = "system_" + GameManager.SystemID;
            GameManager.SystemID++;

            // Generate a random icon
            int randomIndex = Random.Range(0, possibleIcons.Length); 
            icon.sprite = possibleIcons[randomIndex];
        }

        // Set to default properties

        nameText.color = new Color(1f, 1f, 1f);
        icon.color = new Color(1f, 1f, 1f);
        nameText.text = nodeName;
        breached = false;
        extracted = false;

        var main = ps.main;
        main.startColor = new Color(1f, 1f, 1f);
        ps.Play();

        // Node properties
        reward = Random.Range(1, 12);
        
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
        var main = ps.main;
        main.startColor = new Color(1f, 1f, 1f);
        ps.Play();
    }

    public void Deselect()
    {
        selectedIcon.SetActive(false);
    }

    public void Bypass()
    {
        icon.color = new Color(0f, 1f, 0f);
        nameText.color = new Color(0f, 1f, 0f);

        var main = ps.main;
        main.startColor = new Color(1f, 0.6f, 0f);
        ps.Play();
    }

    public void Extract()
    {
        icon.color = new Color(1f, 0f, 1f);
        nameText.color = new Color(1f, 0f, 1f);
        GameManager.balance += reward;

        var main = ps.main;
        main.startColor = new Color(1f, 1f, 0f);
        ps.Play();
    }


}
