using System;
using UnityEngine;

public class ScriptedScene : MonoBehaviour 
{
    public string id;
    public bool happened;
    public Action action;
    public bool playerKeepsControls;
    public bool skippable;
    public SceneType sceneType;
    

    public void StartScene()
    {
        happened = false;

        switch (sceneType)
        {
            case SceneType.Cutscene:
                Logger.AddLog($"Scene Type \"Cutscene\" not implemented.", $"ScriptedScene.StartScene ({id})", 3, true);
                // TODO: IMPLEMENT
                break;
            case SceneType.ModalSequence:
                // TODO: IMPLEMENT
                break;
        }
        
        action.Invoke();
    }
    
}