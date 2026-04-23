using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using TMPro;

public class Maintenance : MonoBehaviour
{
    // Repair Variables
    const float SINGLE_APP_REPAIR_TIME = 2f;
    const float ALL_APP_REPAIR_TIME = 5f;
    private bool isRepairing = false;

    // App Status Text
    public TMP_Text terminalStatusText;
    public TMP_Text blackMarketStatusText;
    public TMP_Text SecurityCenterstatusText;

    // Warning Sign
    public GameObject warningSign;
    

    void Awake()
    {
        GameManager.updateAppStatus.AddListener(UpdateAppStatus);
    }

    // For repairing apps
    // Apps are indexed:
    // 0: Terminal
    // 1: Black Market
    // 2: Security Center
    // 3: All apps
    IEnumerator RepairAppCoroutine(int index)
    {
        // Choose which app to repair based on index
        switch (index)
        {
            // Terminal
            case 0:
                Debug.Log("Starting Terminal Repair...");

                // Wait the time to repair the app
                float t = 0f;
                while (t < SINGLE_APP_REPAIR_TIME)
                {
                    t += Time.deltaTime;
                    yield return null;
                }

                // Repair the app
                GameManager.isTerminalWorking = true;
                isRepairing = false;

                Debug.Log("Terminal Repaired.");
                GameManager.updateAppStatus.Invoke();
                break;

            // Black Market
            case 1:
                Debug.Log("Starting Black Market Repair...");

                // Wait the time to repair the app
                t = 0f;
                while (t < SINGLE_APP_REPAIR_TIME)
                {
                    t += Time.deltaTime;
                    yield return null;
                }

                // Repair the app
                GameManager.isBlackMarketWorking = true;
                isRepairing = false;

                Debug.Log("Black Market Repaired.");
                GameManager.updateAppStatus.Invoke();
                break;
            
            // Security Center
            case 2:
                Debug.Log("Starting Security Center Repair...");

                // Wait the time to repair the app
                t = 0f;
                while (t < SINGLE_APP_REPAIR_TIME)
                {
                    t += Time.deltaTime;
                    yield return null;
                }

                // Repair the app
                GameManager.isSecurityCenterWorking = true;
                isRepairing = false;

                Debug.Log("Security Center Repaired.");
                GameManager.updateAppStatus.Invoke();
                break;

            // All apps
            case 3:
                Debug.Log("Starting All Apps Repair...");

                // Wait the time to repair the app
                t = 0f;
                while (t < ALL_APP_REPAIR_TIME)
                {
                    t += Time.deltaTime;
                    yield return null;
                }

                // Repair the apps
                GameManager.isTerminalWorking = true;
                GameManager.isBlackMarketWorking = true;
                GameManager.isSecurityCenterWorking = true;
                isRepairing = false;

                Debug.Log("All Apps Repaired.");
                GameManager.updateAppStatus.Invoke();
                break;

        }
    }

    // For Starting the Coroutine to repair apps
    public void RepairApp(int index)
    {
        // Only Repair if not already repairing.
        if (!isRepairing)
        {
            isRepairing = true;
            StartCoroutine(RepairAppCoroutine(index));
        }
        
    }

    // For Updating the App Status Text Panel
    void UpdateAppStatus()
    {
        // Terminal
        if (GameManager.isTerminalWorking)
        {
            terminalStatusText.text = "<color=\"green\">Terminal</color> ------------ <color=\"green\">Good</color>";
        }
        else
        {
            terminalStatusText.text ="<color=\"green\">Terminal</color> ------------ <color=\"red\">Down</color>";
        }

        // Black Market
        if (GameManager.isBlackMarketWorking)
        {
            blackMarketStatusText.text = "<color=#ff00ff>Black Market</color> ------- <color=\"green\">Good</color>";
        }
        else
        {
            blackMarketStatusText.text = "<color=#ff00ff>Black Market</color> ------- <color=\"red\">Down</color>";
        }
        
        // Security Center
        if (GameManager.isSecurityCenterWorking)
        {
            SecurityCenterstatusText.text = "<color=#00ffff>Security Center</color> ---- <color=\"green\">Good</color>";
        }
        else
        {
            SecurityCenterstatusText.text = "<color=#00ffff>Security Center</color> ---- <color=\"red\">Down</color>";
        }

        // Update warning icon
        if (!GameManager.isSecurityCenterWorking || !GameManager.isBlackMarketWorking || !GameManager.isTerminalWorking)
        {
            warningSign.SetActive(true);
        }
        else
        {
            warningSign.SetActive(false);
        }
    }
    
    
}
