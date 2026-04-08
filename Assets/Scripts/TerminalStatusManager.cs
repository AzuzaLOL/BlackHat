using UnityEngine;
using UnityEngine.Events;

public class TerminalStatusManager : MonoBehaviour
{
    public Terminal terminal;
    public Typing typing;
    public GameObject notWorkingCoverImage;

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
            terminal.enabled = false;
            typing.enabled = false;
            notWorkingCoverImage.SetActive(true);
        }
        else
        {
            terminal.enabled = true;
            typing.enabled = true;
            notWorkingCoverImage.SetActive(false);
        }
    }
}
