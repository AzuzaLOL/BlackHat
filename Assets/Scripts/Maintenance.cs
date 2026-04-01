using UnityEngine;
using System.Collections;

public class Maintenance : MonoBehaviour
{
    const float SINGLE_APP_REPAIR_TIME = 2f;
    const float ALL_APP_REPAIR_TIME = 5f;
    private bool isRepairing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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

    
    
    
}
