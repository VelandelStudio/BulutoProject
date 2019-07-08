using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TranslationService
{
    [RequireComponent(typeof(Text))]
    public class GUIUnlocalizedText : MonoBehaviour
    {
        private Text textField;
        [SerializeField]private string key;

        private void Awake()
        {
            textField = GetComponent<Text>();
            if (!textField)
            {
                Debug.LogError("The GameObject " + gameObject + " has a GUIUnlocalizedText without Text field... Destroying.");
                Destroy(this);
            }
        }

        private void Start()
        {
            textField.text = TranslationManager.INSTANCE.api.GetUnlocalizedString(key);
        }
    }
}
