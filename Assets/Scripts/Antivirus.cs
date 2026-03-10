using UnityEngine;
using TMPro;

public class Antivirus : MonoBehaviour
{
    public TMP_Text issuesText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RunScan()
    {
        int issues = 0;
        issues += GameManager.moneyDrainAmount;
        string issuesColor = "green";

        if (issues > 0)
        {
            issuesColor = "red";
        }

        issuesText.text = "<color=\"" + issuesColor + "\">" + issues + "</color> Issues Found";
    }
    
    public void DisinfectSystem()
    {
        int issues = 0;
        issues += GameManager.moneyDrainAmount;
        string issuesColor = "green";


        GameManager.moneyDrainAmount = 0;
        GameManager.moneyDrainTimer = 0;

        issuesText.text = "<color=\"" + issuesColor + "\">" + issues + "</color> Issues Fixed";
    }
}
