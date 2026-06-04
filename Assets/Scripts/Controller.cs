using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static double Energy;
    public List<Generator> generators;

    [SerializeField] private Logger logger;
    [SerializeField] private TMPro.TMP_Text energyText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Energy = 0;
        generators = new List<Generator>();
        energyText.text = "Energy: 0";
        
        AddGenerator("Energy", 100, 1);
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
    
    public static void AddEnergy(double amount)
    {
        Energy += amount;
    }
    
    public static void SubtractEnergy(double amount)
    {
        Energy -= amount;
    }

    public void AddGenerator(string _id, float _energyToGenerate, float _timeout)
    {
        generators.Add(new Generator()
        {
            id = _id,
            energyToGenerate = _energyToGenerate,
            timeout = _timeout
        });
        
        generators[^1].Setup();
        
        logger.AddLog($"Controller.AddGenerator: Added generator with id \"{_id}\"", 1);
    }
}
