using System.Collections.Generic;
using Nodes;
using UnityEngine;

public class Generator
{
    // The Logic for the generator is a bit weird, but changing it would take effort and im too lazy right now :p
    // so to future me or anyone who dares to look at this shitty code, here is a little crash course:
    // Each generator is instantiated by Controller, who sets all of the required variables and puts them in a single
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
        if (Controller.Quarks < quarkCost) return;
        
        Controller.SubtractResource(energyCost, Resource.Energy);
        Controller.SubtractResource(quarkCost, Resource.Quark);
        
        float _b = 1;
        foreach (NodeBoost boost in boosts)
        {
            _b *= 1 + (boost.active ? boost.scale : 0);
        }
        
        Logger.AddLog($"Adding {amountToGenerate * _b} {resource}; Boost multiplier: {_b}", $"Generator.Generate ({id})", 0);
        Controller.AddResource(amountToGenerate * _b, resource);
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
