using UnityEngine;

public class Constants
{
    public const byte LOG_LEVEL = 0;

    public const float SKILLTREE_CONNECTOR_LINE_WIDTH = 0.5f;
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