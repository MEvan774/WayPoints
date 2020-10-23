using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    private void Awake()
    {
        foreach (var button in GetComponentsInChildren<HotbarButton>())
            button.OnButtonClicked += ButtonOnButtonClicked;
    }

    private void ButtonOnButtonClicked(int buttonNumber)
    {
        Debug.Log(message: $"Button {buttonNumber} clicked!");
    }
}
