using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranslationService
{
    /// <summary>
    /// API of the Translation Service. We should contact this API via the Service associated.
    /// The API Contains method that can be used by other services.
    /// </summary>
    public class TranslationAPI
    {
        private TranslationEngine engine;

        public TranslationAPI(TranslationEngine engine)
        {
            this.engine = engine;
        }

        /// <summary>
        /// Retrieve the localized string from the unlocalized one (the key).
        /// </summary>
        /// <param name="key"></param>
        /// <returns>The Localized String associated to the key, from the current language.</returns>
        public string GetLocalizedString(string key)
        {
            return engine.UnocalizedStrings.ContainsKey(key) ? engine.UnocalizedStrings[key] : TranslationConstants.ERROR_KEY_PATTERN + key;
        }

        /// <summary>
        /// Reloads the entire data by switching the language.
        /// Be careful, we are currently not able to refresh the elements that have already asked for a translation. This will come in the future with an event system. 
        /// </summary>
        /// <param name="newLang"></param>
        public void ReloadAll(TranslationConstants.Languages newLang)
        {
            if(engine.currentLang == newLang) { return; }

            engine.LoadAllUnlocalizedStrings(newLang);
        }
    }
}