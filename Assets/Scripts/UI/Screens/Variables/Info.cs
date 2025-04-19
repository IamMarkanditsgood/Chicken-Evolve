using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Info : BasicScreen
{
    public Button _back;

    private void Start()
    {
        _back.onClick.AddListener(Close);
    }

    private void OnDestroy()
    {
        _back.onClick.RemoveListener(Close);
    }


    public override void ResetScreen()
    {
    }

    public override void SetScreen()
    {
    }

    private void Close()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Profile);
    }
}
