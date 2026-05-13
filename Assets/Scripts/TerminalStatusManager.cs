using UnityEngine;
using UnityEngine.Events;
using FMODUnity;

public class TerminalStatusManager : MonoBehaviour
{
    public GameObject[] objectsToDisable;
    public GameObject notWorkingStaticCoverImage;
    public GameObject notWorkingBorderCoverImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.updateAppStatus.AddListener(IsTerminalWorking);
    }
    
    // For recieving the terminal down event from GameManager
    void IsTerminalWorking()
    {
        if (!GameManager.isTerminalWorking)
        {
            foreach (GameObject obj in objectsToDisable)
            {
                obj.SetActive(false);
            }

            notWorkingStaticCoverImage.SetActive(true);
            notWorkingBorderCoverImage.SetActive(true);
        }
        else
        {
            foreach (GameObject obj in objectsToDisable)
            {
                obj.SetActive(true);
            }

            notWorkingStaticCoverImage.SetActive(false);
            notWorkingBorderCoverImage.SetActive(false);
        }
    }
}
