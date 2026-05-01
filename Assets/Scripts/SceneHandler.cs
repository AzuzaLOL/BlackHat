using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneHandler : MonoBehaviour
{
   

    public static void SwitchScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
