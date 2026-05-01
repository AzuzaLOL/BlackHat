using UnityEngine;
using FMODUnity;

public class MenuAudioManager : MonoBehaviour
{
    public StudioEventEmitter startEmitter;

    [FMODUnity.ParamRef]
    public string gameStartParam;

    void Awake()
    {
        // startEmitter.TriggerOnce = true;
        // FMODUnity.RuntimeManager.StudioSystem.setParameterByName(gameStartParam, 0);
        // if (!startEmitter.IsActive){
            
        // }
        startEmitter.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // START GAMEPLAY
    public void startGame()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName(gameStartParam, 1);
    }
}
