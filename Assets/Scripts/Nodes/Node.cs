using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Nodes
{
    public abstract class Node : MonoBehaviour
    {
        public NodeType nodeType;
        public string id;
        public string title;
        public bool visible;
        public bool unlocked;
        private Vector3 scale;

        public TMP_Text nodeTitleObject;
        public TMP_Text nodeCostObject;
        public GameObject nodeObject;
        public GameObject parentNode;
    
        public int nodeLevel;
        public float baseCost;
        public float costMultiplier;
        public Sprite sprite;

        public float energyCost;
        public float quarkCost;
        
        public abstract float CalculateCost();
        public abstract void BuyNode();
        public abstract string FormatTitle();
        public abstract void ExecuteUniqueUpdateFunction();
        public abstract void ExecuteUniqueStartFunction();
        
        public void Start()
        {
            scale = nodeType == NodeType.Generator ? Constants.NODE_SIZE_GENERATOR : Constants.NODE_SIZE_UPGRADE;
            
            ExecuteUniqueStartFunction();
            nodeCostObject.gameObject.transform.localScale = Constants.NODE_COST_TEXT_SCALE;
            
            Controller.RegisterNode(this);
            DrawLineToParent();
        }

        public void ClickAction()
        {
            if (Controller.SelectedNode == id) BuyNode();
            else Controller.SetSelectedNode(id);
        }
    
        public void Update()
        {
            if (parentNode)
            {
                if (parentNode.GetComponent<Node>().unlocked)
                {
                    visible = true;

                    if (parentNode.GetComponent<Node>().nodeLevel >= 1)
                    {
                        unlocked = true;
                    }
                }
                else
                {
                    unlocked = false;
                    visible = false;
                }
            }
            
            if (!visible)
            {
                nodeObject.transform.localScale = Vector3.zero;
                return;
            }
            nodeObject.transform.localScale = scale;
            
            nodeTitleObject.text = FormatTitle();
            nodeCostObject.text = unlocked ? $"{CalculateCost()} Energy" : "Locked";
            
            ExecuteUniqueUpdateFunction();
        }

        private void DrawLineToParent()
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