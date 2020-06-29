using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

internal sealed class SetupState : MonoBehaviour
{
    [SerializeField]
    private Button startButton;

    private StateManager stateManager;

    public event Action StartClicked;

    [Inject]
    private void Construct(StateManager stateManager)
    {
        this.stateManager = stateManager;
    }

    private void OnDestroy()
    {
        startButton.onClick.RemoveListener(OnStartClicked);
    }

    private void OnStartClicked()
    {
        StartClicked?.Invoke();
    }

    private void Reset()
    {
        startButton = GetComponentInChildren<Button>();
    }

    private void Start()
    {
        startButton.onClick.AddListener(OnStartClicked);
    }
}