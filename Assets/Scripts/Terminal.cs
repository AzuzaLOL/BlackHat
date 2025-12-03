using UnityEngine;

public class Terminal : MonoBehaviour

{
    public GameObject[] nodes;
    public GameObject root;
    public InfoPanel infoPanel;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RegenerateNodes()
    {
        // Currently regenerates root too
        root.GetComponent<SystemNode>().RegenerateNode();
        infoPanel.SelectNode(root.GetComponent<SystemNode>());
        
        for (int i = 0; i < nodes.Length; i++)
        {
            SystemNode node = nodes[i].GetComponent<SystemNode>();
            node.RegenerateNode();
        }
    }
}
