using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StandarInventaryButton : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI valueText;
    public Image image;
    private Button button;

    public Button Button { get => button; set => button = value; }

    private void Awake()
    {
        Button = GetComponent<Button>();
    }

    public void SetButtonAction(UnityAction action)
    {
        Button.onClick.AddListener(action);
    }
}
