using Nodes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeInfo : MonoBehaviour
{
    public Button button;
    
    public TMP_Text titleText;
    public TMP_Text bodyText;

    public string title;
    public string body;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.SelectedNode == "none")
        {
            gameObject.transform.localScale = Vector3.zero;
            button.onClick.RemoveAllListeners();
            return;
        }
        
        gameObject.transform.localScale = Vector3.one;
        var node = Controller.FindNodeById(Controller.SelectedNode);
        
        title = node.title;
        body = Constants.NodeInfoBodyText[node.id];
        
        titleText.text = title;
        bodyText.text = body;
        
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(node.ClickAction);
        button.GetComponentInChildren<TMP_Text>().text = $"Buy ({node.CalculateCost()} Energy)";
    }
}
