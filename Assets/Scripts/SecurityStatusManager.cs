using UnityEngine;
using UnityEngine.Events;

public class SecurityStatusManager : MonoBehaviour
{
    public GameObject[] objectsToDisable;
    public GameObject notWorkingStaticCoverImage;
    public GameObject notWorkingBorderCoverImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.updateAppStatus.AddListener(IsSecurityCenterWorking);
    }
    
    // For recieving the market down event from GameManager
    void IsSecurityCenterWorking()
    {
        if (!GameManager.isSecurityCenterWorking)
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
