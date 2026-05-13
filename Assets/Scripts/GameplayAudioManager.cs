using UnityEngine;
using FMODUnity;
using System.Collections;

public class GameplayAudioManager : MonoBehaviour
{
    public StudioEventEmitter gameplayEmitter;

    [FMODUnity.ParamRef]
    public string paymentTimerParam;
    [FMODUnity.ParamRef]
    public string vpnParam;
    [FMODUnity.ParamRef]
    public string alarmParam;

    void Start()
    {
        StartCoroutine(CheckBanksLoaded());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateTimerParam()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName(paymentTimerParam, GameManager.paymentTimer);
    }

    public IEnumerator CheckBanksLoaded()
    {
        while (!RuntimeManager.HaveAllBanksLoaded)

        {
            yield return null; 
            // Wait until all banks are loaded
        }

        // Ensure FMOD is fully initialized before playing sounds
        yield return new WaitForSeconds(0.1f);
        gameplayEmitter.Play();

    }

}
