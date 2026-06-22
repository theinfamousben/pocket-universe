using UnityEngine;

public class Constants
{
    public const sbyte LOG_LEVEL = -1;
    
}

public enum Resource
{
    Energy,
    Quark
}

[CreateAssetMenu(menuName = "ScriptableObjects/NodeBoost")]
public class NodeBoost : ScriptableObject
{
    public string id;
    public float scale;
    public bool active;
}