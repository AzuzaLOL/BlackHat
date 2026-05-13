using UnityEngine;
using System.Collections;
using FMODUnity;

public class AppOpenStatic : MonoBehaviour
{
    public enum App {Terminal, Market, Maintenance, Security, GameOver}
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
                    StartCoroutine(AppStartup(0.3f));
                }
                else
                {
                    staticSound.Play();
                }
                break;
            case App.Market:
                if (GameManager.isBlackMarketWorking)
                {
                    StartCoroutine(AppStartup(0.3f));
                }
                else
                {
                    staticSound.Play();
                }
                break;
            case App.Security:
                if (GameManager.isSecurityCenterWorking)
                {
                    StartCoroutine(AppStartup(0.3f));
                }
                else
                {
                    staticSound.Play();
                }
                break;
            case App.GameOver:
                staticSound.Play();
                StartCoroutine(AppStartup(4f));
                break;
            default:
                StartCoroutine(AppStartup(0.3f));
                break;
        }
    }

    public IEnumerator AppStartup(float duration)
    {
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }

        notWorkingStaticCoverImage.SetActive(true);
        notWorkingBorderCoverImage.SetActive(true);
            
        yield return new WaitForSeconds(duration);

        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(true);
        }

        if(app == App.GameOver)
        {
            staticSound.Stop();
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
