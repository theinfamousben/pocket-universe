using UnityEngine;
using TMPro;

namespace Nodes
{
    public class UpgradeNode : Node
    {
        public string generatorId;
        public NodeBoost relatedBoost;

        public override float CalculateCost() => baseCost;

        public override void BuyNode()
        {
            Logger.AddLog($"Requested buy node", $"UpgradeNode.BuyNode ({id})", 0);

            if (nodeLevel >= 1) return; // Is it already unlocked?
            if (Controller.Energy < CalculateCost()) return;
            
            Controller.SubtractResource(CalculateCost(), Resource.Energy);
            nodeLevel++;

            foreach (Generator generator in Controller.Generators)
            {
                if (generator.id.StartsWith(generatorId))
                {
                    relatedBoost.active = true;
                }
            }
        }

        public override void ExecuteUniqueStartFunction()
        {
            relatedBoost.active = false;
        }
        
        public override void ExecuteUniqueUpdateFunction()
        {
            if (nodeLevel >= 1)
            {
                nodeCostObject.gameObject.transform.localScale = Vector3.zero;
            }
        }

        public override string FormatTitle() => $"{title}";
    }
}
