using UnityEngine;
using TMPro;

//namespace Node;
public class UpgradeNode : MonoBehaviour
{
    public string id;
    public string title;
    public bool visible;
    public bool unlocked;
    public float cost;
    
    public TMP_Text nodeTitleObject;
    public TMP_Text nodeCostObject;
    public GameObject nodeObject;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nodeTitleObject.text = title;
        nodeCostObject.text = cost.ToString("F2") + " Energy";
    }

    // Update is called once per frame
    void Update()
    {
        if (!visible)
        {
            nodeObject.transform.localScale = Vector3.zero;
            return;
        }
        
        nodeObject.transform.localScale = Vector3.one;
    }

    public void BuyNode()
    {
        Logger.AddLog($"UpgradeNode.BuyNode ({id}): Requested buy node");
        if (Controller.Energy < cost) return;

        Controller.Energy -= cost;
        unlocked = true;
        
    }
}
