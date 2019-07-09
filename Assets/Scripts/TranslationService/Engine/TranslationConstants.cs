using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranslationService
{
    public class TranslationConstants
    {
        public static Dictionary<Languages, string> UnlocalizedFilePath { get; private set; } = new Dictionary<Languages, string>()
        {
            { Languages.FR_fr, "unlocalized_FR_fr.json" },
        };

        public enum Languages
        {
            EN_en = 0,
            FR_fr = 1
        }

        public const string ERROR_KEY_PATTERN = "#ERROR_$";
    }
}

