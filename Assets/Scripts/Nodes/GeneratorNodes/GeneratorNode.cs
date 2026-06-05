using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;

public class GeneratorNode : MonoBehaviour
{
    public string id;
    public string title;
    public bool visible;
    public bool unlocked;

    public TMP_Text nodeTitleObject;
    public TMP_Text nodeCostObject;
    
    public int nodeLevel;
    public List<string> assignedGenerators;
    public float baseCost;
    public float costMultiplier;
    public Resource resource;
    public float baseTimeout;
    
    
    public void BuyNode()
    {
        Logger.AddLog($"GeneratorNode.BuyNode ({id}): Requested buy node");
        if (Controller.Energy < baseCost * Mathf.Pow(costMultiplier, nodeLevel)) return;
        
        Controller.SubtractResource(baseCost * Mathf.Pow(costMultiplier, nodeLevel), Resource.Energy);
        nodeLevel++;
        Controller.AddGenerator($"{id}_{nodeLevel}", 1, baseTimeout, resource);
        assignedGenerators.Add($"{id}_{nodeLevel}");
        
    }
    
    public void Update()
    {
        nodeTitleObject.text = $"{title} (Level {nodeLevel})";
        nodeCostObject.text = $"Cost: {(baseCost * Mathf.Pow(costMultiplier, nodeLevel)).ToString("F2")} Energy";
    }

}
