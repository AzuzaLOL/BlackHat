using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneHandler : MonoBehaviour
{
    public static GameObject manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (manager == null)
        {
            manager = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SwitchScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
