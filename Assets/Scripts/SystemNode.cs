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
    public bool hackFailed = false;
    

    // Visuals
    public GameObject selectedIcon;
    public bool isRoot = false;

    public TMP_Text nameText;

    public Sprite[] possibleIcons;
    public Image icon;

    public ParticleSystem ps;


    // NODE SPAWNING
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
            // Node Name
            string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int nameLength = Random.Range(3, 6);
            nodeName = "";

            for(int i = 0; i < nameLength; i++)
            {
                nodeName += alphabet[Random.Range(0, alphabet.Length)];
            }


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
        hackFailed = false;

        var main = ps.main;
        main.startColor = new Color(1f, 1f, 1f);
        ps.Play();

        // NODE PROPERTIES:
        // Firewall and encryption within 2 levels of the player search level
        int fwMin = GameManager.searchLevel - 2;
        int fwMax = GameManager.searchLevel + 2;

        int enMin = GameManager.searchLevel - 2;
        int enMax = GameManager.searchLevel + 2;

        // Clamp min levels
        if (fwMin <=0) {
            fwMin = 1;
        }

        if (enMin <=0) {
            enMin = 1;
        }

        // Generate levels
        firewall = Random.Range(fwMin, fwMax + 1);
        encryption = Random.Range(enMin, enMax + 1);

        // Generate reward based on combined node level
        int totalLevel = firewall + encryption;
        int rwMin = totalLevel * 2;
        int rwMax = totalLevel * 4;

        reward = Random.Range(rwMin, rwMax + 1);


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

    public void FailHack()
    {
        icon.color = new Color(1f, 0f, 0f);
        nameText.color = new Color(1f, 0f, 0f);

        var main = ps.main;
        main.startColor = new Color(1f, 0f, 0f);
        ps.Play();


        // Keep track of failed hacks and add money drain
        GameManager.numHacksFailed += 1;

        if (GameManager.numHacksFailed >= GameManager.HACKS_REQUIRED_FOR_MONEY_DRAIN)
        {
            GameManager.moneyDrainAmount += 1;
        }
    }


}
