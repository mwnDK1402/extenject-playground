using ModestTree;
using UnityEngine;
using Zenject;

namespace RPS
{
    internal sealed class StateManager : MonoBehaviour
    {
        private ChoiceState choice;
        private ResultState result;
        private SetupState setup;

        [Inject]
        private void Construct(
            SetupState setup,
            ChoiceState choice,
            ResultState result)
        {
            this.setup = setup;
            this.choice = choice;
            this.result = result;
        }

        private void OnChoiceTaken(ResultState.ResultChoice resultChoice)
        {
            switch (resultChoice)
            {
                case ResultState.ResultChoice.Rematch:
                    SetChoiceState();
                    break;

                case ResultState.ResultChoice.MainMenu:
                    SetSetupState();
                    break;

                default:
                    Assert.That(false);
                    break;
            }
        }

        private void OnCountdownEnded()
        {
            SetResultState();
        }

        private void OnDestroy()
        {
            setup.StartClicked -= OnStartClicked;
            choice.CountdownEnded -= OnCountdownEnded;
            result.ChoiceTaken -= OnChoiceTaken;
        }

        private void OnStartClicked()
        {
            SetChoiceState();
        }

        private void SetChoiceState()
        {
            setup.gameObject.SetActive(false);
            choice.gameObject.SetActive(true);
            result.gameObject.SetActive(false);
        }

        private void SetResultState()
        {
            setup.gameObject.SetActive(false);
            choice.gameObject.SetActive(false);
            result.gameObject.SetActive(true);
        }

        private void SetSetupState()
        {
            setup.gameObject.SetActive(true);
            choice.gameObject.SetActive(false);
            result.gameObject.SetActive(false);
        }

        private void Start()
        {
            SetSetupState();

            setup.StartClicked += OnStartClicked;
            choice.CountdownEnded += OnCountdownEnded;
            result.ChoiceTaken += OnChoiceTaken;
        }
    }
}