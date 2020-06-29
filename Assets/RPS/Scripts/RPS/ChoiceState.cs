using RPS;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using Zenject;

internal sealed class ChoiceState : MonoBehaviour
{
    private WaitForSeconds countdownDelay;

    [SerializeField]
    private float countdownDelayTime = 1f;

    private CountdownText countdownText;

    public event Action CountdownEnded;

    public float CountdownTime { get; set; }

    [Inject]
    private void Construct(CountdownText countdownText)
    {
        this.countdownText = countdownText;
    }

    private IEnumerator CountdownCoroutine()
    {
        var countdownInterval = new WaitForSeconds(CountdownTime / 3);

        yield return countdownDelay;

        for (int i = 3; i >= 1; i--)
        {
            countdownText.ShowCountdown(i);
            yield return countdownInterval;
        }

        countdownText.ShowCountdown(0);

        yield return countdownDelay;

        CountdownEnded?.Invoke();
    }

    private void OnEnable()
    {
        StartCoroutine(CountdownCoroutine());
    }

    private void Start()
    {
        countdownDelay = new WaitForSeconds(countdownDelayTime);
    }
}