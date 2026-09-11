using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Modal_Menu : MonoBehaviour
{
    private void Start()
    {
        gameObject.transform.localScale = Vector3.zero;
    }

    public void Close()
    {
        gameObject.transform.localScale = Vector3.zero;
    }

    public void Open()
    {
        gameObject.transform.localScale = Constants.VECTOR3_2;
    }
}
