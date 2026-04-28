using UnityEngine;
using System.Collections;
using FMODUnity;

public class AppOpenStatic : MonoBehaviour
{
    public enum App {Terminal, Market, Maintenance, Security}
    public App app;
    public StudioEventEmitter staticSound;

    public GameObject[] objectsToDisable;
    public GameObject notWorkingStaticCoverImage;
    public GameObject notWorkingBorderCoverImage;


    void Awake()
    {
        GameManager.updateAppStatus.AddListener(UpdateStaticSound);
    }

    void OnEnable()
    {
        switch (app)
        {
            case App.Terminal:
                if (GameManager.isTerminalWorking)
                {
                    StartCoroutine(AppStartup());
                }
                else
                {
                    staticSound.Play();
                }
                break;
            case App.Market:
                if (GameManager.isBlackMarketWorking)
                {
                    StartCoroutine(AppStartup());
                }
                else
                {
                    staticSound.Play();
                }
                break;
            case App.Security:
                if (GameManager.isSecurityCenterWorking)
                {
                    StartCoroutine(AppStartup());
                }
                else
                {
                    staticSound.Play();
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

    public void OnDisable()
    {
        staticSound.Stop();
    }

    public void UpdateStaticSound()
    {
        if(!gameObject.activeSelf)
        {
            return;
        }

        switch (app)
        {
            case App.Terminal:
                if (!GameManager.isTerminalWorking)
                {
                    staticSound.Play();
                }
                else
                {
                    staticSound.Stop();
                }
                break;
            case App.Market:
                if (!GameManager.isBlackMarketWorking)
                {
                    staticSound.Play();
                }
                else
                {
                    staticSound.Stop();
                }
                break;
            case App.Security:
                if (!GameManager.isSecurityCenterWorking)
                {
                    staticSound.Play();
                }
                else
                {
                    staticSound.Stop();
                }
                break;
            default:
                break;
        }
    }
}
