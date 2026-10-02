using UnityEngine;

namespace Nodes
{
    public class UpgradeNode : Node
    {
        public string appendedGenerator;
        public NodeBoost relatedBoost;

        public override float CalculateCost() => baseCost;

        protected override void BuyNode()
        {
            Logger.AddLog($"Requested buy node", $"UpgradeNode.BuyNode ({id})", 0);

            if (nodeLevel >= 1) return; // Is it already unlocked?
            if (Controller.Energy < CalculateCost()) return;
            if (!unlocked) return;
            
            Controller.SubtractResource(CalculateCost(), Resource.Energy);
            nodeLevel++;

            foreach (Generator generator in Controller.Generators)
            {
                if (generator.id.StartsWith(appendedGenerator))
                {
                    relatedBoost.active = true;
                }
            }
        }

        protected override void ExecuteUniqueStartFunction()
        {
            relatedBoost.active = false;
        }

        protected override void ExecuteUniqueUpdateFunction()
        {
            if (nodeLevel >= 1)
            {
                nodeCostObject.gameObject.transform.localScale = Vector3.zero;
            }
        }

        protected override string FormatTitle() => $"{title}";
    }
}
