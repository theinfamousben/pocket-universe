using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Constants
{
    public const sbyte LOG_LEVEL = -1;


    [Header("Color Defaults")] 
    
    public static readonly Color BUTTON_COLOR_DEFAULT = Color.white;
    public static readonly Color BUTTON_COLOR_IMPORTANT_GREEN = Color.green;
    public static readonly Color BUTTON_COLOR_IMPORTANT_RED = Color.red;
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