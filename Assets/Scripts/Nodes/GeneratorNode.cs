using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;

//namespace Nodes;
public class GeneratorNode : MonoBehaviour
{
    public string id;
    public string title;
    public bool visible;
    public bool unlocked;

    public TMP_Text nodeTitleObject;
    public TMP_Text nodeCostObject;
    public GameObject nodeObject;
    public GameObject parentNode;
    
    public int nodeLevel;
    public List<string> assignedGenerators;
    public float baseCost;
    public float costMultiplier;
    public float baseResourceToGenerate;
    public Resource resource;
    public float baseTimeout;
    public List<NodeBoost> boosts;
    
    
    public void BuyNode()
    {
        Logger.AddLog($"GeneratorNode.BuyNode ({id}): Requested buy node");
        if (Controller.Energy < baseCost * Mathf.Pow(costMultiplier, nodeLevel)) return;
        
        Controller.SubtractResource(baseCost * Mathf.Pow(costMultiplier, nodeLevel), Resource.Energy);
        nodeLevel++;
        Controller.AddGenerator($"{id}_{nodeLevel}", baseResourceToGenerate, baseTimeout, resource, boosts);
        assignedGenerators.Add($"{id}_{nodeLevel}");
    }
    
    public void Update()
    {
        if (!visible)
        {
            nodeObject.transform.localScale = Vector3.zero;
            return;
        }
        nodeObject.transform.localScale = Vector3.one;

        nodeTitleObject.text = $"{title} (L{nodeLevel})";
        nodeCostObject.text = $"{(baseCost * Mathf.Pow(costMultiplier, nodeLevel)):F2} Energy";
    }

}
