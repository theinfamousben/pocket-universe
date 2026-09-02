using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Nodes;

public class Controller : MonoBehaviour
{
    public static double Energy;
    public static double Quarks;
    public static List<Generator> Generators = new();
    public static List<Node> Nodes = new();
    public static string SelectedNode = "none";
    
    [FormerlySerializedAs("TestModal")] public Modal_Test testModal;
    public Modal_Alert alertModal;

    [SerializeField] private double startingEnergy;
    [SerializeField] private double startingQuarks;
    

    [SerializeField] private TMP_Text energyText;
    [SerializeField] private TMP_Text quarkText;

    void Start()
    {
        SelectedNode = "none";
        Energy = startingEnergy;
        Quarks = startingQuarks;
        
        energyText.text = "Energy: 0";
        quarkText.text = "Quarks: 0";

        testModal.Close();
        alertModal.Close();

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
                Logger.AddLog($"Unknown Resource: {resource}", $"Controller.AddResource", 3, true);
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
                Logger.AddLog($"Unknown Resource: {resource}", $"Controller.SubtractResource", 3, true); 
                break;
        }
    }
    
    public static Generator FindGenerator(string id) => Generators.Find(g => g.id == id);
    public static Node FindNodeById(string id) => Nodes.Find(n => n.id == id);

    public GameObject ResolveGameObject(string id) => GameObject.Find(id);

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
        Generators.Add(new Generator
        {
            id = _id,
            amountToGenerate = _amountToGenerate,
            timeout = _timeout,
            resource = _resource,
            boosts = _boosts,
            
            // put the costs last so it looks neat
            energyCost = _energyCost,
            quarkCost = _quarkCost
        });
        
        Generators[^1].Setup();
        
        Logger.AddLog($"Added generator with id \"{_id}\"", $"Controller.AddGenerator");
    }
    
    public static void SetSelectedNode(string id)
    {
        Logger.AddLog($"Selected node {id}", $"Controller.SetSelectedNode");
        SelectedNode = id;
    }

    public static void RegisterNode(Node node)
    {
        if (Nodes == null) Nodes = new List<Node>();
        Nodes.Add(node);
    }

}
