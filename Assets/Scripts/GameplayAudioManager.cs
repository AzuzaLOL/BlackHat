using UnityEngine;
using FMODUnity;

public class GameplayAudioManager : MonoBehaviour
{
    public StudioEventEmitter gameplayEmitter;

    [FMODUnity.ParamRef]
    public string paymentTimerParam;

    void Awake()
    {
        gameplayEmitter.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateTimerParam()
    {
        gameplayEmitter.SetParameter(paymentTimerParam, GameManager.paymentTimer);
    }

}
