using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UGettext;
using UnityEngine;

namespace RPS
{
    [CreateAssetMenu]
    public sealed class SupportedLanguages : ScriptableObject
    {
        public int[] IDs;

#if UNITY_EDITOR

        private static readonly Regex ValidateRegex = new Regex($"Resources/{I18n.LocalePath}$");

        public void UpdateLanguages()
        {
            var assetsPath = Application.dataPath;
            var matchingDirs = Directory.GetDirectories(
                assetsPath,
                "*",
                SearchOption.AllDirectories)
                .Where(dir => ValidateRegex.IsMatch(dir.Replace("\\", "/")));

            switch (matchingDirs.Count())
            {
                case 0:
                    Debug.LogError("No matching directories.");
                    break;

                case 1:
                    var localeDirs = Directory.GetDirectories(matchingDirs.Single());
                    var cultureIDs = new List<int>();
                    foreach (var localeDir in localeDirs)
                    {
                        var localeName = new DirectoryInfo(localeDir).Name;
                        try
                        {
                            var culture = new CultureInfo(localeName);
                            cultureIDs.Add(culture.LCID);
                        }
                        catch (CultureNotFoundException e)
                        {
                            Debug.LogWarning($"{localeDir} is not a valid locale directory.");
                        }
                    }

                    IDs = cultureIDs.ToArray();
                    break;

                default:
                    Debug.LogError("Too many matching directories.");
                    break;
            }
        }

        private void OnValidate()
        {
            UpdateLanguages();
        }

#endif
    }
}