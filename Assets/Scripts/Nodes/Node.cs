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
        
        void Start()
        {
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
            if (!visible)
            {
                nodeObject.transform.localScale = Vector3.zero;
                return;
            }
            nodeObject.transform.localScale = Vector3.one;
            
            nodeTitleObject.text = FormatTitle();
            nodeCostObject.text = $"{CalculateCost()} Energy";
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