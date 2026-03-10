using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameObject manager;
    
    public static int SystemID = 1;
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

    // Related to security center
    public static float vpnTimer = 0;
    public static bool forceHackFail = false;



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

    // Handle the payment and VPN timers
    void Update() {
        paymentTimer -= Time.deltaTime;
        vpnTimer += Time.deltaTime;

        if (paymentTimer <= 0) {
            Debug.Log("Game Over!");
        }
    }
    
}
