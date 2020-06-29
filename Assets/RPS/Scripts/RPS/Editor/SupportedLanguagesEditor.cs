using RPS;
using UnityEditor;
using UnityEngine;

namespace RPSEditor
{
    [CustomEditor(typeof(SupportedLanguages))]
    internal sealed class SupportedLanguagesEditor : Editor
    {
        private readonly GUIContent buttonContent =
            new GUIContent("Update Languages");

        private new SupportedLanguages target;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button(buttonContent))
                target.UpdateLanguages();
        }

        private void OnEnable()
        {
            target = (SupportedLanguages)base.target;
        }
    }
}