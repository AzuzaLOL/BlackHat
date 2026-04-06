using UnityEngine;
using FMODUnity;

public class MenuAudioManager : MonoBehaviour
{
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
    }
}
