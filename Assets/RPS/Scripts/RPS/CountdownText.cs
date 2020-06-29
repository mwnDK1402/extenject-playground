using ModestTree;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RPS
{
    [RequireComponent(typeof(TextTranslator), typeof(Animator))]
    internal sealed class CountdownText : MonoBehaviour
    {
        private const string PopTextKey = "PopText";

        private Animator anim;

        private TextTranslator text;

        private Dictionary<int, string> textByNumber = new Dictionary<int, string>()
        {
            [3] = "countdown3",
            [2] = "countdown2",
            [1] = "countdown1",
            [0] = "GO!"
        };

        public void ShowCountdown(int number)
        {
            Assert.That(textByNumber.ContainsKey(number));
            var countdownText = textByNumber[number];
            text.SetOriginalText(countdownText);

            anim.SetTrigger(PopTextKey);
        }

        private void Start()
        {
            text = GetComponent<TextTranslator>();
            anim = GetComponent<Animator>();
        }
    }
}