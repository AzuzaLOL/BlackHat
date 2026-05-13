using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using FMODUnity;

public class Antivirus : MonoBehaviour
{
    public TMP_Text issuesText;
    public Image progressBar;
    const float SCAN_TIME = 1f;
    const float DISINFECT_TIME = 3f;
    private bool isAntivirusActive = false;

    // Audio
    public StudioEventEmitter scanSound;
    public StudioEventEmitter disinfectSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator RunScan()
    {
        Debug.Log("Starting Antivirus Scan...");
        isAntivirusActive = true;
        issuesText.text = "Scanning...";
        scanSound.Play();

        // Wait the time to scan
        float t = 0f;
        while (t < SCAN_TIME)
        {
            t += Time.deltaTime;
            progressBar.fillAmount = t / SCAN_TIME;
            yield return null;
        }

        int issues = 0;
        issues += GameManager.moneyDrainAmount;
        issues += GameManager.numHacksFailed;
        string issuesColor = "green";

        if (issues > 0)
        {
            issuesColor = "red";
        }

        issuesText.text = "<color=\"" + issuesColor + "\">" + issues + "</color> Issues Found";
        Debug.Log("Scan Complete");
        progressBar.fillAmount = 0;
        isAntivirusActive = false;
    }

    public void ScanCoroutine()
    {
        if (!isAntivirusActive)
        {
            StartCoroutine("RunScan");
        }
    }
    
    public IEnumerator DisinfectSystem()
    {
        Debug.Log("Starting Antivirus Disinfect...");
        isAntivirusActive = true;
        issuesText.text = "Disinfecting...";
        disinfectSound.Play();

        // Wait the time to disinfect
        float t = 0f;
        while (t < DISINFECT_TIME)
        {
            t += Time.deltaTime;
            progressBar.fillAmount = t / DISINFECT_TIME;
            yield return null;
        }


        int issues = 0;
        issues += GameManager.moneyDrainAmount;
        issues += GameManager.numHacksFailed;
        string issuesColor = "green";


        GameManager.moneyDrainAmount = 0;
        GameManager.moneyDrainTimer = 0;
        GameManager.numHacksFailed = 0;

        issuesText.text = "<color=\"" + issuesColor + "\">" + issues + "</color> Issues Fixed";
        Debug.Log("Disinfect Complete");
        progressBar.fillAmount = 0;
        isAntivirusActive = false;
    }

     public void DisinfectCoroutine()
    {
        if (!isAntivirusActive)
        {
            StartCoroutine("DisinfectSystem");
        }
    }
}
