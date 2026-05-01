using UnityEngine;
using FMODUnity;

public class SceneHandlerWrapper : MonoBehaviour
{
     public StudioEventEmitter musicEmitter;
    [FMODUnity.ParamRef]
    public string gameStartParam;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // For Changing the Scene in a non-static way
    public void SwitchScene(int index)
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName(gameStartParam, 0);
        musicEmitter.Stop();

        SceneHandler.SwitchScene(index);
    }
}
