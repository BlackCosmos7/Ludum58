using UnityEngine;

public class LanguageButton : MonoBehaviour
{
    public void SetRussian()
    {
        LanguageManager.Instance.SetLanguage(LanguageManager.Language.Russian);
    }

    public void SetEnglish()
    {
        LanguageManager.Instance.SetLanguage(LanguageManager.Language.English);
    }
}