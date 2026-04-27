using UnityEngine;
using System.Collections;

public class AppOpenStatic : MonoBehaviour
{
    public enum App {Terminal, Market, Maintenance, Security}
    public App app;

    public GameObject[] objectsToDisable;
    public GameObject notWorkingStaticCoverImage;
    public GameObject notWorkingBorderCoverImage;

    void OnEnable()
    {
        switch (app)
        {
            case App.Terminal:
                if (GameManager.isTerminalWorking)
                {
                    StartCoroutine(AppStartup());
                }
                break;
            case App.Market:
                if (GameManager.isBlackMarketWorking)
                {
                    StartCoroutine(AppStartup());
                }
                break;
            case App.Security:
                if (GameManager.isSecurityCenterWorking)
                {
                    StartCoroutine(AppStartup());
                }
                break;
            default:
                StartCoroutine(AppStartup());
                break;
        }
    }

    public IEnumerator AppStartup()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }

        notWorkingStaticCoverImage.SetActive(true);
        notWorkingBorderCoverImage.SetActive(true);
            
        yield return new WaitForSeconds(0.3f);

        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(true);
        }

        notWorkingStaticCoverImage.SetActive(false);
        notWorkingBorderCoverImage.SetActive(false);
    }
}
