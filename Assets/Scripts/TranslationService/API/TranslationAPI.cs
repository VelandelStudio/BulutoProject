using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranslationService
{
    public class TranslationAPI
    {
        private TranslationEngine engine;

        public TranslationAPI(TranslationEngine engine)
        {
            this.engine = engine;
        }

        public string GetUnlocalizedString(string key)
        {
            return engine.UnocalizedStrings.ContainsKey(key) ? engine.UnocalizedStrings[key] : TranslationConstants.ERROR_KEY_PATTERN + key;
        }

        public void ReloadAll(TranslationConstants.Languages newLang)
        {
            if(engine.currentLang == newLang) { return; }

            engine.LoadAllUnlocalizedStrings(newLang);
        }
    }
}