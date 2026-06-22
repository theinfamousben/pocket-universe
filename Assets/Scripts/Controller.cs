using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static double Energy;
    public static double Quarks;
    public static List<Generator> Generators;

    [SerializeField] private TMP_Text energyText;
    [SerializeField] private TMP_Text quarkText;
    
    void Start()
    {
        Energy = 100;
        Generators = new List<Generator>();
        energyText.text = "Energy: 0";
        quarkText.text = "Quarks: 0";
        
        //AddGenerator("Energy", 100, 1, Resource.Energy, new List<NodeBoost>());
    }

    void Update()
    {
        foreach (Generator generator in Generators)
        {
            generator.RefreshTimer();
        }

        energyText.text = "Energy: " + Energy.ToString("F2");
        quarkText.text = "Quarks: " + Quarks.ToString("F2");
    }
    
    public static void AddResource(double amount, Resource resource)
    {
        switch (resource)
        {
            case Resource.Energy:
                Energy += amount;
                break;
            case Resource.Quark:
                Quarks += amount;
                break;
            default:
                Logger.AddLog($"Controller.AddResource: Unknown Resource: {resource}", 3);
                break;
        }
    }
    
    public static void SubtractResource(double amount, Resource resource)
    {
        switch (resource)
        {
            case Resource.Energy:
                Energy -= amount;
                break;
            case Resource.Quark:
                Quarks -= amount;
                break;
            default: 
                Logger.AddLog($"Controller.SubtractResource: Unknown Resource: {resource}", 3); 
                break;
        }
    }
    
    public static Generator FindGenerator(string id) => Generators.Find(g => g.id == id);

    public static void AddGenerator
        (
            string _id, 
            float _amountToGenerate, 
            float _timeout, 
            Resource _resource, 
            List<NodeBoost> _boosts,
            float _energyCost,
            float _quarkCost
        )
    {
        Generators.Add(new Generator()
        {
            id = _id,
            amountToGenerate = _amountToGenerate,
            timeout = _timeout,
            resource = _resource,
            boosts = _boosts,
            energyCost = _energyCost,
            quarkCost = _quarkCost
        });
        
        Generators[^1].Setup();
        
        Logger.AddLog($"Controller.AddGenerator: Added generator with id \"{_id}\"");
    }
}
