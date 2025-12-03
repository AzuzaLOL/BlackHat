using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameObject manager;
    
    public static int SystemID = 1;
    public static int Balance = 0;

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

    public static void SwitchScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    
}
