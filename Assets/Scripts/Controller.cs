using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static double Energy;
    public List<Generator> generators;

    [SerializeField] private TMPro.TMP_Text energyText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Energy = 0;
        generators = new List<Generator>();
        energyText.text = "Energy: 0";
        
        AddGenerator("Energy", 100, 1, Resource.Energy);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Generator generator in generators)
        {
            generator.RefreshTimer();
        }

        energyText.text = "Energy: " + Energy.ToString("F2");
    }
    
    public static void AddResource(double amount, Resource resource)
    {
        switch (resource)
        {
            case Resource.Energy:
                Energy += amount;
                break;
            default:
                Logger.AddLog($"Unknown Resource: {resource}", 3);
                break;
        }
    }
    
    public static void SubtractEnergy(double amount, Resource resource)
    {
        switch (resource)
        {
            case Resource.Energy:
                Energy -= amount;
                break;
            default: 
                Logger.AddLog($"Unknown Resource: {resource}", 3); 
                break;
        }
    }

    public void AddGenerator(string _id, float _energyToGenerate, float _timeout, Resource _resource)
    {
        generators.Add(new Generator()
        {
            id = _id,
            energyToGenerate = _energyToGenerate,
            timeout = _timeout,
            resource = _resource 
        });
        
        generators[^1].Setup();
        
        Logger.AddLog($"Controller.AddGenerator: Added generator with id \"{_id}\"", 1);
    }
}
