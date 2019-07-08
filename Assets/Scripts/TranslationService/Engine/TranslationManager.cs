using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TranslationService
{
    public class TranslationManager
    {
        public TranslationAPI api { get; private set; }

        private static TranslationManager instance;
        public static TranslationManager INSTANCE
        {
            get
            {
                if (instance == null)
                {
                    instance = new TranslationManager();
                }
                return instance;
            }
        }

        private TranslationManager()
        {
            TranslationEngine engine = new TranslationEngine(TranslationConstants.Languages.FR_fr);
            api = new TranslationAPI(engine);
        }
    }
}
