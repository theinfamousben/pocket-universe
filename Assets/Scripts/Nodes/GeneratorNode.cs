using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;

namespace Nodes
{
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
        public Sprite sprite;

        public float energyCost;
        public float quarkCost;

        void Start()
        {
            DrawLineToParent();
        }

        public void ClickAction()
        {
            if (Controller.SelectedNode == id) BuyNode();
            else Controller.SetSelectedNode(id);
        }
        
        public float CalculateCost() => baseCost * Mathf.Pow(costMultiplier, nodeLevel);
        
        public void BuyNode()
        {
            if (CameraController.Dragging) return;
            
            Logger.AddLog($"Requested buy node", $"GeneratorNode.BuyNode ({id})", 0);
            if (Controller.Energy < CalculateCost()) return;
        
            Controller.SubtractResource(CalculateCost(), Resource.Energy);
            nodeLevel++;
            Controller.AddGenerator
            (
                _id: $"{id}_{nodeLevel}", 
                _amountToGenerate: baseResourceToGenerate, 
                _timeout: baseTimeout, 
                _resource: resource, 
                _boosts: boosts,
                
                // put the costs last so it looks neat
                _energyCost: energyCost,
                _quarkCost: quarkCost
            );
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
        
        public void DrawLineToParent()
        {
            if (parentNode == null) return;

            LineRenderer lr = GetComponent<LineRenderer>();
            if (lr == null)
            {
                lr = gameObject.AddComponent<LineRenderer>();
                lr.material = new Material(Shader.Find("Sprites/Default"));
                lr.widthMultiplier = 0.05f;
                lr.positionCount = 2;
                lr.useWorldSpace = true;
                lr.numCapVertices = 8;
                lr.numCornerVertices = 8;
                lr.startColor = Color.white;
                lr.endColor = Color.white;
            }

            lr.positionCount = 2;
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, parentNode.transform.position);
        }
        
        public string GetTitle() => title;
        public float GetNodeLevel() => nodeLevel;
        public float GetCost() => CalculateCost();
    }
}
