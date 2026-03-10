using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class BalanceText : MonoBehaviour
{
    public TMP_Text textObj;
    public ParticleSystem ps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        textObj = GetComponent<TMP_Text>();
        ps = GetComponent<ParticleSystem>();
        GameManager.drainMoney.AddListener(UpdateBalance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBalance() {
        textObj.text = "Balance: <color=#FFFF00>$" + GameManager.balance + "</color>";
        ps.Play();
    }

    void OnEnable()
    {
        textObj.text = "Balance: <color=#FFFF00>$" + GameManager.balance + "</color>";
    }
    
}
