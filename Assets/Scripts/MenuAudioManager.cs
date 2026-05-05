using UnityEngine;
using FMODUnity;
using System.Collections;

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
        // startEmitter.Play();
        StartCoroutine(CheckBanksLoaded());
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

    public IEnumerator CheckBanksLoaded()
    {
        while (!RuntimeManager.HaveAllBanksLoaded)

        {
            yield return null; 
            // Wait until all banks are loaded
        }

        // Ensure FMOD is fully initialized before playing sounds
        yield return new WaitForSeconds(0.1f);
        startEmitter.Play();

    }
}
