using TMPro;
using UnityEngine;

public class TestModal : MonoBehaviour
{
    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Open
    (
        string title,
        string body,

        T_Property button1,
        T_Property button2
    )
    {
        gameObject.SetActive(true);
        
        TMP_Text titleText = transform.Find("Header Text").GetComponent<TMP_Text>();
        TMP_Text bodyText = transform.Find("Content Text").GetComponent<TMP_Text>();
        
        titleText.text = title;
        bodyText.text = body;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
