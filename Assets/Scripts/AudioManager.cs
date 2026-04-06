using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static StudioEventEmitter gameplayEmitter;
    public static StudioEventEmitter startEmitter;

    [FMODUnity.ParamRef]
    public string game_start;

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        game_start = "1";
    }
}
