using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameObject manager;

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





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (manager == null)
        {
            manager = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public static void SwitchScene(int index)
    {
        SceneManager.LoadScene(index);
    }


    void Update()
    {
        // Handle the payment and VPN timers
        paymentTimer -= Time.deltaTime;
        vpnTimer += Time.deltaTime;

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
        int appIndex = Random.Range(0, 4);

    }
}
