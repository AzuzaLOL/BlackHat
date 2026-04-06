using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public StudioEventEmitter gameplayEmitter;
    public StudioEventEmitter startEmitter;

    [FMODUnity.ParamRef]
    public string gameStartParam;

    void Awake()
    {
        startEmitter.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // START GAMEPLAY
    public void startGame()
    {
        startEmitter.SetParameter(gameStartParam, 1);
        // startEmitter.Stop();
    }
}
