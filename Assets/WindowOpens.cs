using UnityEngine;

public class WindowOpens : MonoBehaviour
{
    public GameObject window;
    
    public void OpenWindow()
    {
        window.SetActive(true);
    }
}
