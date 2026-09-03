using System;
using Nodes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeInfo : MonoBehaviour
{
    public Button button;
    
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public TMP_Text effectText;

    public string title;
    public string description;
    public string effect;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.SelectedNode == "none")
        {
            gameObject.transform.localScale = Vector3.zero;
            button.onClick.RemoveAllListeners();
            return;
        }
        
        gameObject.transform.localScale = Vector3.one;
        var node = Controller.FindNodeById(Controller.SelectedNode);
        
        title = node.title;
        description = Constants.NodeInfoDescriptionText[node.id];

        effectText.gameObject.transform.localScale = Vector3.one;
        try
        {
            effect = Constants.NodeInfoEffectText[node.id];
        }
        catch (Exception e)
        {
            effectText.gameObject.transform.localScale = Vector3.zero;
        }
        
        titleText.text = title;
        descriptionText.text = description;
        effectText.text = effect;
        
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(node.ClickAction);
        button.GetComponentInChildren<TMP_Text>().text = node.unlocked 
            ? node.nodeType == NodeType.Upgrade && node.nodeLevel >= 1 
                ? "Unlocked" 
                : $"Buy ({node.CalculateCost()} Energy)"
            : "Locked";
        // DISGUSTING nested ternary operator, but actually quite simple:
        // If the node is locked, just return locked
        // If the node is an upgrade and already bought, return "Unlocked" since we only want 1 node bought ever
        // Otherwise, just return the Buy Text
    }
}
