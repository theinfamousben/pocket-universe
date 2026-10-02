using System.Collections.Generic;
using UnityEngine;

public class Generator
{
    // The Logic for the generator is a bit weird, but changing it would take effort, and I'm too lazy right now :p
    // so to future me or anyone who dares to look at this shitty code, here is a little crash course:
    // Each generator is instantiated by Controller, who sets all the required variables and puts them in a single
    // list. The list is only to be interacted with through Controller.FindGenerator(), because it isn't organized at all.
    // Why is it like this? Convenience. Writing this comment seems easier than reworking the entire Logic for generators.
    
    
    public string id;
    public float amountToGenerate;
    public float timeout;
    private float timer;
    public Resource resource;
    public List<NodeBoost> boosts;

    public float energyCost;
    public float quarkCost;

    public void Setup()
    {
        timer = 0;
    }

    private void Generate()
    {
        if (Controller.Energy < energyCost) return;
        
        Controller.SubtractResource(energyCost, Resource.Energy);
        if (quarkCost > 0)
            Controller.SubtractResource(quarkCost, Resource.Quark);
        
        float b = 1;
        if (boosts != null)
        {
            foreach (NodeBoost boost in boosts)
            {
                if (boost && boost.active)
                    b *= 1 + boost.scale;
            }
        }
        
        if (resource != Resource.Energy && resource != Resource.Quark)
        {
            Logger.AddLog($"Invalid resource type: {resource}", $"Generator.Generate ({id})", 3, true);
            return;
        }
        
        Logger.AddLog($"Adding {amountToGenerate * b} {resource}; Boost multiplier: {b}", $"Generator.Generate ({id})", 0);
        Controller.AddResource(amountToGenerate * b, resource);
        timer = 0;
    }

    public void RefreshTimer()
    {
        timer += Time.deltaTime;
        if (timer >= timeout)
        {
            Generate();
        }
    }
}
