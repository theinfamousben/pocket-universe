using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Modal_Test : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text bodyText;

    public Button button1Object;
    public Button button2Object;
    
    public void Close()
    {
        gameObject.transform.localScale = Vector3.zero;
    }

    public void Open
    (
        
        string title,
        string body,

        T_Property button1,
        T_Property button2
    )
    {
        Logger.AddLog($"TestModal.Open: Opening modal", 0);
        
        titleText.text = title;
        bodyText.text = body;

        button1Object.gameObject.SetActive(false);
        button2Object.gameObject.SetActive(false);

        if (button1.active)
        {
            button1Object.gameObject.SetActive(true);
            button1Object.GetComponentInChildren<TMP_Text>().text = button1.text;
            button1Object.GetComponent<Image>().color = button1.color;
            button1Object.onClick.RemoveAllListeners();
            button1Object.onClick.AddListener(() => button1.action());
        }

        if (button2.active)
        {
            button2Object.gameObject.SetActive(true);
            button2Object.GetComponentInChildren<TMP_Text>().text = button2.text;
            button2Object.GetComponent<Image>().color = button2.color;
            button2Object.onClick.RemoveAllListeners();
            button2Object.onClick.AddListener(() => button2.action());
        }
        
        gameObject.transform.localScale = Vector3.one;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
