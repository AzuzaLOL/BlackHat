using UnityEngine;
using TMPro;

public class BalanceText : MonoBehaviour
{
    public TMP_Text textObj;
    public ParticleSystem ps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        textObj = GetComponent<TMP_Text>();
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBalance() {
        textObj.text = "Balance: <color=#FFFF00>$" + GameManager.balance + "</color>";
        ps.Play();
    }

    void OnEnable() {
        textObj.text = "Balance: <color=#FFFF00>$" + GameManager.balance + "</color>";
    }
}
