using UnityEngine;
using FMODUnity;

public class GameplayAudioManager : MonoBehaviour
{
    public StudioEventEmitter gameplayEmitter;

    [FMODUnity.ParamRef]
    public string paymentTimerParam;
    [FMODUnity.ParamRef]
    public string vpnParam;

    void Start()
    {
        gameplayEmitter.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateTimerParam()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName(paymentTimerParam, GameManager.paymentTimer);
    }

}
