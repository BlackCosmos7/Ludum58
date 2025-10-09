using UnityEngine;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{
    public string key;
    private Text textComponent;

    void Start()
    {
        textComponent = GetComponent<Text>();
        UpdateText();
    }

    public void UpdateText()
    {
        if (LanguageManager.Instance != null)
            textComponent.text = LanguageManager.Instance.GetText(key);
    }
}
