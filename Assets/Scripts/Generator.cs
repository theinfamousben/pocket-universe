using UnityEngine;

public class Generator
{
    public string id;
    public float energyToGenerate;
    public float timeout;
    public float timer;

    public void Setup()
    {
        timer = 0;
    }
    
    public void Generate()
    {
        Controller.AddEnergy(energyToGenerate);
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
