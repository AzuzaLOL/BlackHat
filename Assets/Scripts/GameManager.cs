using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static int balance = 0;

    // Upgradable stats related to black market
    public static float paymentTimer = 300;
    public static int paymentCost = 300;
    public static int numberPayments = 0;

    public static int bypassLevel = 1;
    public static int bypassCost = 50;

    public static int extractLevel = 1;
    public static int extractCost = 50;

    public static int searchLevel = 1;
    public static int searchCost = 50;

    // Related to VPN security center
    public static float vpnTimer = 0;
    public static bool forceHackFail = false;

    public GameObject securityWarningSign;
    public GameObject terminalSecurityWarningSign;
    public GameObject vpnWarningSign;
    public GameObject antivirusWarningSign;

    // For Antivirus in security center
    public static int numHacksFailed = 0;
    public static int moneyDrainAmount = 0;
    public static float moneyDrainTimer = 0;
    public static float moneyDrainInterval = 1;
    public const int HACKS_REQUIRED_FOR_MONEY_DRAIN = 5;
    public static UnityEvent drainMoney = new UnityEvent();

    // App status for Maintenance
    public static bool isTerminalWorking = true;
    public static bool isBlackMarketWorking = true;
    public static bool isSecurityCenterWorking = true;
    public static UnityEvent updateAppStatus = new UnityEvent();

    public static float maintenanceEventTimer = 0;
    public static float maintenanceEventInterval = 5;

    // Audio Manager
    public GameplayAudioManager gameplayAudioManager;


    void Awake()
    {
        
    }


    void Update()
    {
        // Handle the payment and VPN timers
        paymentTimer -= Time.deltaTime;
        vpnTimer += Time.deltaTime;

        if (vpnTimer > 60 || moneyDrainAmount > 0)
        {
            securityWarningSign.SetActive(true);
            terminalSecurityWarningSign.SetActive(true);
        }
        else
        {
            securityWarningSign.SetActive(false);
            terminalSecurityWarningSign.SetActive(false);
        }

        if (vpnTimer > 60)
        {
            vpnWarningSign.SetActive(true);
        }
        else
        {
            vpnWarningSign.SetActive(false);
        }

        if (moneyDrainAmount > 0)
        {
            antivirusWarningSign.SetActive(true);
        }
        else
        {
            antivirusWarningSign.SetActive(false);
        }

        // Timer for Audio
        gameplayAudioManager.UpdateTimerParam();

        if (paymentTimer <= 0)
        {
            // Game Ends
            Debug.Log("Game Over!");
        }

        // Money Drain
        if (moneyDrainAmount > 0)
        {
            moneyDrainTimer += Time.deltaTime;
            if (moneyDrainTimer > moneyDrainInterval)
            {
                balance -= moneyDrainAmount;
                moneyDrainTimer -= moneyDrainInterval;
                drainMoney.Invoke();
            }
        }


        // Timed Events
        maintenanceEventTimer += Time.deltaTime;
        if (maintenanceEventTimer >= maintenanceEventInterval)
        {
            // Trigger the maintenence event
            MaintenanceEvent();
            maintenanceEventTimer = 0;
        }
    }

    // Maintenance Event
    void MaintenanceEvent()
    {
        // Choose an app to go down
        int appIndex = Random.Range(0, 3);

        // Emit the event for chosen app
        switch(appIndex)
        {
            // Terminal
            case 0:
                isTerminalWorking = false;
                updateAppStatus.Invoke();
                break;
            // Black Market
            case 1:
                isBlackMarketWorking = false;
                updateAppStatus.Invoke();
                break;
            // Security Center
            case 2:
                isSecurityCenterWorking = false;
                updateAppStatus.Invoke();
                break;
        }
    }
}
