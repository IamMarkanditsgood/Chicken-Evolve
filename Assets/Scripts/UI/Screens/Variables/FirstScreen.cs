using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FirstScreen : BasicScreen
{
    public Button a;

    private void Start()
    {
        a.onClick.AddListener(ScreenGame);


    }
    private void OnDestroy()
    {
        a.onClick.RemoveListener(ScreenGame);
    }
    public override void ResetScreen()
    {
    }

    public override void SetScreen()
    {
    }

    private void ScreenGame()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Game);
    }
}
