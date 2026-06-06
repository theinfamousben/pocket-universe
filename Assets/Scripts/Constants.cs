using UnityEngine;

public class Constants
{
    public const byte LOG_LEVEL = 0;
}

public enum Resource
{
    Energy,
       
}

[CreateAssetMenu(menuName = "ScriptableObjects/NodeBoost")]
public class NodeBoost : ScriptableObject
{
    public string id;
    public float scale;
    public bool active;
}