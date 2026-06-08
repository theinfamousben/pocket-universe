using UnityEngine;

public class Logger : MonoBehaviour
{
    public static void AddLog(string message, int level = 1) // level: -1 = trace, 0 = debug, 1 = info, 2 = warning, 3 = error
    {
        if (level < Constants.LOG_LEVEL) return;
        
        switch (level)
        {
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
    }
}
