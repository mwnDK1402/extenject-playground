using System;
using UnityEngine;
using UnityEngine.UI;

internal sealed class ResultState : MonoBehaviour
{
    [SerializeField]
    private Button
        rematchButton,
        mainMenuButton;

    public event Action<ResultChoice> ChoiceTaken;

    public enum ResultChoice
    {
        Rematch,
        MainMenu
    }

    private void OnDestroy()
    {
        rematchButton.onClick.RemoveListener(OnRematchButtonClicked);
        mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
    }

    private void OnMainMenuButtonClicked()
    {
        ChoiceTaken?.Invoke(ResultChoice.MainMenu);
    }

    private void OnRematchButtonClicked()
    {
        ChoiceTaken?.Invoke(ResultChoice.Rematch);
    }

    private void Reset()
    {
        var buttons = GetComponentsInChildren<Button>();
        if (buttons.Length == 2)
        {
            rematchButton = buttons[0];
            mainMenuButton = buttons[1];
        }
    }

    private void Start()
    {
        rematchButton.onClick.AddListener(OnRematchButtonClicked);
        mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
    }
}