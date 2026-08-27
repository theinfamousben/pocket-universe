using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour
{
    public Dictionary<sbyte, string> logLevels = new Dictionary<sbyte, string>()
    {
        {-1, "Trace"},
        { 0, "Debug" },
        { 1, "Info" },
        { 2, "Warning" },
        { 3, "Error" }
    };
    
    public static void AddLog(string message, string whoCalled, sbyte level = 1, bool createModal = false) 
        // level:
        // -1 = trace
        // 0 = debug
        // 1 = info
        // 2 = warning
        // 3 = error
    {
        if (level < Constants.LOG_LEVEL) return;
        
        switch (level)
        {
            case -1:
                Debug.Log(message);
                break;
            case 0:
                Debug.Log(message);
                break;
            case 1:
                Debug.Log(message);
                break;
            case 2:
                Debug.LogWarning(message);
                break;
            case 3:
                Debug.LogError(message);
                break;
            default:
                Debug.Log(message + "\n\n Invalid log level: " + level);
                break;
        }

        if (createModal)
        {
            Controller controller = GameObject.FindObjectOfType<Controller>();
            if (controller == null)
            {
                Debug.LogError("Logger.AddLog: Controller not found for modal creation.");
                return;
            }
            
            controller.alertModal.Open
            (
                title: whoCalled,
                body: message,
                
                button1: new T_Property()
                {
                    active = true,
                    text = "OK",
                    color = Constants.BUTTON_COLOR_IMPORTANT_GREEN,
                    action = () => controller.alertModal.Close()
                },
                button2: new T_Property()
                {
                    active = false
                }
            );
        }
    }
}
