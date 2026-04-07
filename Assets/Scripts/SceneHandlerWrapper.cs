using UnityEngine;

public class SceneHandlerWrapper : MonoBehaviour
{
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
        SceneHandler.SwitchScene(index);
    }
}
