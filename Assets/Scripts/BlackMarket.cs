using UnityEngine;
using TMPro;

public class BlackMarket : MonoBehaviour
{
    public TMP_Text bypassLevelText;
    public TMP_Text extractLevelText;
    public TMP_Text searchLevelText;

    public TMP_Text bypassCostText;
    public TMP_Text extractCostText;
    public TMP_Text searchCostText;

    public TMP_Text numberPaymentsText;
    public TMP_Text timeRemainingText;
    public TMP_Text debtCostText;

    public BalanceText balanceText;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Update text based on data in GameManager
        bypassLevelText.text = "Level: " + GameManager.bypassLevel;
        extractLevelText.text = "Level: " + GameManager.extractLevel;
        searchLevelText.text = "Level: " + GameManager.searchLevel;
        
        bypassCostText.text = "$" + GameManager.bypassCost;
        extractCostText.text = "$" + GameManager.extractCost;
        searchCostText.text = "$" + GameManager.searchCost;

        numberPaymentsText.text = "Payments: " + GameManager.numberPayments;
        timeRemainingText.text = "Time Remaining:\n" + Mathf.FloorToInt(GameManager.paymentTimer);
        debtCostText.text = "$" + GameManager.paymentCost;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the payment timer text
        timeRemainingText.text = "Time Remaining:\n" + Mathf.FloorToInt(GameManager.paymentTimer);
        
    }

    // Methods for purchasing
    public void UpgradeBypass() {
        if (GameManager.balance >= GameManager.bypassCost) {
            GameManager.balance -= GameManager.bypassCost;
            GameManager.bypassLevel += 1;
            GameManager.bypassCost *= 2;

            balanceText.UpdateBalance();
            Start();
        }
    }

    public void UpgradeExtract() {
        if (GameManager.balance >= GameManager.extractCost) {
            GameManager.balance -= GameManager.extractCost;
            GameManager.extractLevel += 1;
            GameManager.extractCost *= 2;

            balanceText.UpdateBalance();
            Start();
        }
    }

    public void UpgradeSearch() {
        if (GameManager.balance >= GameManager.searchCost) {
            GameManager.balance -= GameManager.searchCost;
            GameManager.searchLevel += 1;
            GameManager.searchCost *= 2;

            balanceText.UpdateBalance();
            Start();
        }
    }

    public void MakePayment() {
        if (GameManager.balance >= GameManager.paymentCost) {
            GameManager.balance -= GameManager.paymentCost;
            GameManager.numberPayments += 1;
            GameManager.paymentCost *= 2;

            balanceText.UpdateBalance();
            // Reset Timer
            GameManager.paymentTimer = 300;
            Start();
        }
    }


}
