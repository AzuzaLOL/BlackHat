using UnityEngine;
using TMPro;

public class VPN : MonoBehaviour
{
    public TMP_Text vpnTimerText;
    public TMP_Text IPText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateIP();
    }
    
    private const int SAFE_VPN_TIME = 30;
    private const int WARNING_VPN_TIME = 60;

    // Update is called once per frame
    void Update()
    {
        // VPN Timer
        string timerColor;
        int vpnTime = Mathf.FloorToInt(GameManager.vpnTimer);


        if (vpnTime < SAFE_VPN_TIME)
        {
            timerColor = "green";
        }
        else if (vpnTime < WARNING_VPN_TIME)
        {
            timerColor = "yellow";

        }
        else
        {
            timerColor = "red";
            GameManager.forceHackFail = true;
        }

        vpnTimerText.text = "Time on current network: <color=\"" + timerColor + "\">" + vpnTime + "s</color>";
    }

    public void ResetVPN()
    {
        // Reset VPN
        GameManager.vpnTimer = 0;
        GameManager.forceHackFail = false;


        // Generate and set new IP text
        GenerateIP();

    }
    
    private void GenerateIP()
    {
        int IPInt1 = Random.Range(0, 256);
        int IPInt2 = Random.Range(0, 256);
        int IPInt3 = Random.Range(0, 256);
        int IPInt4 = Random.Range(0, 256);

        string IP = IPInt1 + "." + IPInt2 + "." + IPInt3 + "." + IPInt4;
        IPText.text = "Current IP <color=\"orange\"> " + IP + "</color>";
    }
}
