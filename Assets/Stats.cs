using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    public TMP_Text stats_text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stats_text.text = "";
        stats_text.text += "Debt Payments Made: " + GameManager.numberPayments;
        stats_text.text += "\n\nTotal Time Lasted: " + Mathf.FloorToInt(GameManager.totalTimeLasted);
        stats_text.text += "\n\nMoney Earned: $" + GameManager.totalMoneyEarned;
        stats_text.text += "\n\nSuccessful Bypasses: " + GameManager.totalSuccessfulBypasses;
        stats_text.text += "\n\nSuccessful Extractions: " + GameManager.totalSuccessfulExtracts;
        stats_text.text += "\n\nFailed Hacks: " + GameManager.totalFailedHacks;
        stats_text.text += "\n\nUpgrades Purchased: " + GameManager.totalUpgradesPurchased;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
