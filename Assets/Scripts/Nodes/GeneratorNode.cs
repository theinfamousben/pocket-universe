using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;

namespace Nodes
{
    public class GeneratorNode : Node
    {

        public List<string> assignedGenerators;
        public float baseResourceToGenerate;
        public Resource resource;
        public float baseTimeout;
        public List<NodeBoost> boosts;
        
        public override float CalculateCost() => baseCost * Mathf.Pow(costMultiplier, nodeLevel);
        
        public override void BuyNode()
        {
            if (CameraController.Dragging) return;
            
            Logger.AddLog($"Requested buy node", $"GeneratorNode.BuyNode ({id})", 0);
            if (!unlocked) return;
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

        public override void ExecuteUniqueStartFunction()
        {
            return;
        }

        public override void ExecuteUniqueUpdateFunction()
        {
            return;
        }
        
        public override string FormatTitle() => $"{title} (L{nodeLevel})";
    }
}
