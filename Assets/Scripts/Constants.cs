using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public static class Constants
{
    public static readonly Dictionary<string, string> NodeInfoDescriptionText = new Dictionary<string, string>
    {
        { "Test", "Test text, blah blah blah" },
        
        // GENERATORS
        { "FundamentalInteraction", "Energy is the capacity of a physical system to perform work or cause a change."},
        { "ElementaryParticle", "Elementary particles are the most basic building blocks of matter and energy in the universe."},
        { "Quark", "Quarks are the elementary building blocks of matter, combining to form protons and neutrons."},
        { "Boson", "Bosons are the messengers of the quantum world, carrying information of the environment."},
        
        // UPGRADES
        { "StrongNuclearInteraction", "The strong nuclear interaction is the fundamental force responsible for holding atomic nuclei together."},
        { "ElectromagneticInteraction", "The electromagnetic interaction is the fundamental force responsible for the behavior of charged particles and the propagation of electromagnetic waves."},
        { "WeakNuclearInteraction", "The weak nuclear interaction is the fundamental force responsible for certain types of radioactive decay and particle interactions."},
        { "GravitationalInteraction", "The gravitational interaction is the fundamental force responsible for the attraction between objects with mass."},
    };

    public static readonly Dictionary<string, string> NodeInfoEffectText = new Dictionary<string, string>
    {
        {"Test", "Test Blah blah"},
        
        // GENERATORS
        { "FundamentalInteraction", "Generates a Base of 1 Energy per second."},
        
        // UPGRADES
        { "StrongNuclearInteraction", "Fundamental Interaction 30% more efficient"},
        { "WeakNuclearInteraction", "Fundamental Interaction 50% more efficient"},
        { "ElectromagneticInteraction", "Fundamental Interaction 75% more efficient" },
        { "GravitationalInteraction", "Fundamental Interaction 100% more efficient" },
    };

    public static readonly Vector3 NODE_SIZE_GENERATOR = new Vector3( 1f, 1f, 1f );
    public static readonly Vector3 NODE_SIZE_UPGRADE = new Vector3( 0.65f, 0.65f, 0.65f );
    public static readonly Vector3 NODE_COST_TEXT_SCALE = new Vector3( 0.5f, 0.5f, 0.5f );
    public static readonly Vector3 NODEINFO_SCALE = new Vector3( 2f, 2f, 2f );
    
    public static readonly sbyte LOG_LEVEL = -1;

    public static readonly float CURRENCY_DISPLAY_Y_PADDING = 20;
    public static readonly float LEFT_SIDEBAR_X_PADDING = 20;
    public static readonly float RIGHT_SIDEBAR_X_PADDING = 20;

    public static readonly Color BUTTON_COLOR_DEFAULT = Color.white;
    public static readonly Color BUTTON_COLOR_IMPORTANT_GREEN = Color.green;
    public static readonly Color BUTTON_COLOR_IMPORTANT_RED = Color.red;

    public static readonly Color NODE_BUTTON_COLOR_DEFAULT = new Color(1f, 1f, 1f, 1f);
    public static readonly Color NODE_BUTTON_COLOR_DISABLED = new Color(0.7843137255f, 0.7843137255f, 0.7843137255f, 0.5019607843f);
    public static readonly Color NODE_BUTTON_COLOR_HIGHLIGHTED = new Color(1f, 1f, 1f, 1f);
    public static readonly Color NODE_BUTTON_COLOR_SELECTED = new Color(0f, 1f, 1f, 1f);
}

public enum Resource
{
    Energy,
    Quark
}

public enum MType
{
    Test,
    Alert
}

public enum SceneType
{
    Cutscene, // TODO: Implement
    ModalSequence,
}


public static class EnumUtil {
    public static IEnumerable<T> GetValues<T>() {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }
}

[CreateAssetMenu(menuName = "ScriptableObjects/NodeBoost")]
public class NodeBoost : ScriptableObject
{
    public string id;
    public float scale;
    public bool active;
}

public class T_Property
{
    public string text;
    public Color color;
    public Action action;
    public bool active;
}

public enum NodeType
{
    Generator,
    Upgrade
}