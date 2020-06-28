using NGettext;
using NGettext.Loaders;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

namespace UGettext
{
    public delegate object ResourcesLoader(string path);

    public class UnityMoLoader : MoLoader
    {
        private const string LCMessages = "LC_MESSAGES";
        private static ResourcesLoader _loader = Resources.Load;
        private TextAsset foundAndLoadedAsset;

        public UnityMoLoader(string domain, string localeDir)
            : base(domain, localeDir)
        {
        }

        public static void SetLoader(ResourcesLoader newLoader) =>
            _loader = newLoader;

        protected override string FindTranslationFile(
                CultureInfo cultureInfo, string domain, string localeDir)
        {
            var possibleFiles = GetPossibleFilePath(
                cultureInfo, domain, localeDir);

            foreach (var possibleFilePath in possibleFiles)
            {
                var configText = _loader(possibleFilePath) as TextAsset;

                if (!configText) continue;

                foundAndLoadedAsset = configText;
                return possibleFilePath;
            }

            return null;
        }

        /// <inheritdoc />
        protected override string GetFileName(
                string localeDir, string domain, string locale)
        {
            var filePath = Path.Combine(
                localeDir, Path.Combine(locale, Path.Combine(LCMessages, domain)));
            filePath = filePath.Replace('\\', '/');
            return filePath;
        }

        /// <inheritdoc />
        protected override void Load(string filePath, Catalog catalog)
        {
            using (var stream = new MemoryStream(foundAndLoadedAsset.bytes))
                Load(stream, catalog);
        }

        private IEnumerable<string> GetPossibleFilePath(
            CultureInfo cultureInfo, string domain, string localeDir)
        {
            var possibleFiles = new[] {
                GetFileName(localeDir, domain, cultureInfo.Name),
                GetFileName(localeDir, domain, cultureInfo.TwoLetterISOLanguageName)
            };

            return possibleFiles;
        }
    }
}