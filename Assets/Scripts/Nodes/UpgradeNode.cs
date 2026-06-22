using UnityEngine;
using TMPro;

namespace Nodes
{
    public class UpgradeNode : MonoBehaviour
    {
        public string id;
        public string generatorId;
        public string title;
        public bool visible;
        public bool unlocked;
        public float cost;
        public NodeBoost relatedBoost;
        
    
        public TMP_Text nodeTitleObject;
        public TMP_Text nodeCostObject;
        public GameObject nodeObject;
        public GameObject parentNode;
    
        void Start()
        {
            nodeTitleObject.text = title;
            nodeCostObject.text = cost.ToString("F2") + " Energy";
        }

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
            Logger.AddLog($"UpgradeNode.BuyNode ({id}): Requested buy node", 0);
            if (Controller.Energy < cost) return;

            Controller.Energy -= cost;
            unlocked = true;

            foreach (Generator generator in Controller.Generators)
            {
                if (generator.id.StartsWith(generatorId))
                {
                    relatedBoost.active = true;
                }
            }
        }
    }
}
