 using Unity.VisualScripting;
 using UnityEngine;

public class HUDController : MonoBehaviour
{
    private GameObject CurrencyDisplay;
    private GameObject SidebarLeft;
    private GameObject SidebarRight;

    private float oldX;
    private float oldY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        CurrencyDisplay = GameObject.Find("CurrencyDisplay");
        SidebarLeft = GameObject.Find("SidebarLeft");
        SidebarRight = GameObject.Find("SidebarRight");
        
        oldX = Screen.width;
        oldY = Screen.height;
    }

    private void AdjustPosition()
    {
        CurrencyDisplay.transform.position = new Vector3(Screen.width / 2f, Screen.height - Constants.CURRENCY_DISPLAY_Y_PADDING, 0);
        SidebarLeft.transform.position = new Vector3(Constants.LEFT_SIDEBAR_X_PADDING, Screen.height / 2f, 0);
        SidebarRight.transform.position = new Vector3(Screen.width - Constants.RIGHT_SIDEBAR_X_PADDING, Screen.height / 2f, 0);
    }

    private void CheckForNewScreenDimensions()
    {
        if (Screen.width != oldX || Screen.height != oldY)
        {
            AdjustPosition();
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckForNewScreenDimensions();
    }
}
