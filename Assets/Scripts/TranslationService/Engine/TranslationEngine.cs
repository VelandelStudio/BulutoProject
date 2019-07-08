using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranslationService
{
    /// <summary>
    /// Engine associated to the Translation Service. 
    /// The engine is able to load datas from a JSON file and store it in a Dictionary. 
    /// </summary>
    public class TranslationEngine
    {
        public Dictionary<string, string> UnocalizedStrings { get; private set; }
        public TranslationConstants.Languages currentLang;

        private JSONParser parser;

        public TranslationEngine(TranslationConstants.Languages lang)
        {
            LoadAllUnlocalizedStrings(lang);
            Debug.Log("Translation Engine is ready to work.");
        }

        /// <summary>
        /// We load all the data contained in the JSON file associated to this language and store it in the UnlocalizedString dictionary.
        /// </summary>
        /// <param name="lang"></param>
        public void LoadAllUnlocalizedStrings(TranslationConstants.Languages lang)
        {
            currentLang = lang;
            InitParser(lang);
            UnlocalizedString[] allstrings = parser.Unmarshall<UnlocalizedString>();
            UnocalizedStrings = new Dictionary<string, string>();
            for (int i = 0; i < allstrings.Length; i++)
            {
                UnocalizedStrings.Add(allstrings[i].key, allstrings[i].value);
            }
        }

        private void InitParser(TranslationConstants.Languages lang)
        {
            if (!TranslationConstants.UnlocalizedFilePath.ContainsKey(lang))
            {
                Debug.LogWarning("TranslationConstants does not contains a file for the language :" + lang + ". Default language FR_fr was selected instead.");
                parser = new JSONParser(TranslationConstants.UnlocalizedFilePath[TranslationConstants.Languages.FR_fr]);
            }
            else
            {
                parser = new JSONParser(TranslationConstants.UnlocalizedFilePath[lang]);
            }
        }
    }

    [System.Serializable]
    public class UnlocalizedString
    {
        public string key;
        public string value;
    }
}
