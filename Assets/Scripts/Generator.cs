using System.Collections.Generic;
using UnityEngine;

public class Generator
{
    public string id;
    public float energyToGenerate;
    public float timeout;
    public float timer;
    public Resource resource;
    public List<NodeBoost> boosts;

    public void Setup()
    {
        timer = 0;
    }
    
    public void Generate()
    {
        float _b = 1;
        foreach (NodeBoost boost in boosts)
        {
            _b += boost.active ? boost.scale : 0;
        }
        
        Controller.AddResource(energyToGenerate * _b, Resource.Energy);
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
