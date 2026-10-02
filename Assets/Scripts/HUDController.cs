using UnityEngine;

public class HUDController : MonoBehaviour
{
    private GameObject currencyDisplay;
    private GameObject sidebarLeft;
    private GameObject sidebarRight;

    private float oldX;
    private float oldY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        currencyDisplay = GameObject.Find("CurrencyDisplay");
        sidebarLeft = GameObject.Find("SidebarLeft");
        sidebarRight = GameObject.Find("SidebarRight");
        
        oldX = Screen.width;
        oldY = Screen.height;
    }

    private void AdjustPosition()
    {
        currencyDisplay.transform.position = new Vector3(Screen.width / 2f, Screen.height - Constants.CURRENCY_DISPLAY_Y_PADDING, 0);
        sidebarLeft.transform.position = new Vector3(Constants.LEFT_SIDEBAR_X_PADDING, Screen.height / 2f, 0);
        sidebarRight.transform.position = new Vector3(Screen.width - Constants.RIGHT_SIDEBAR_X_PADDING, Screen.height / 2f, 0);
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
