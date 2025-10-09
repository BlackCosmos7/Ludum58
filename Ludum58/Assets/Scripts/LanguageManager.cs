using UnityEngine;
using System.Collections.Generic;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Instance;

    public enum Language
    {
        English,
        Russian
    }

    public Language currentLanguage = Language.English;

    private Dictionary<string, string> russianTexts = new Dictionary<string, string>();
    private Dictionary<string, string> englishTexts = new Dictionary<string, string>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadLanguages();
            LoadSavedLanguage();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void LoadLanguages()
    {
        englishTexts["play"] = "Play";
        russianTexts["play"] = "Играть";

        englishTexts["menu"] = "Menu";
        russianTexts["menu"] = "Меню";

        englishTexts["Author"] = "Authors";
        russianTexts["Author"] = "Авторы";

        englishTexts["Language"] = "Language";
        russianTexts["Language"] = "Язык";

        englishTexts["Next"] = "Next";
        russianTexts["Next"] = "Дальше";

        englishTexts["Win"] = "Win";
        russianTexts["Win"] = "Победа";

        englishTexts["Restart"] = "Restart";
        russianTexts["Restart"] = "Заново";

        englishTexts["Over"] = "Everyone guessed that you're not a specialist, you were fired.";
        russianTexts["Over"] = "Все догадались, что ты не специалист, тебя уволили.";

        englishTexts["Attempt"] = "Attempts:";
        russianTexts["Attempt"] = "Попытки:";

        englishTexts["Cont"] = "Continue";
        russianTexts["Cont"] = "Дальше";

        englishTexts["Pause"] = "Pause";
        russianTexts["Pause"] = "Пауза";

        englishTexts["DecVaz"] = "Decorative Vase";
        russianTexts["DecVaz"] = "Ваза декоративная";

        englishTexts["DecVazAbout"] = "Considered a luxury item these days, this vase used to be the standard of that time, with two handles, a thin neck, and patterns in the form of sharp leaves.";
        russianTexts["DecVazAbout"] = "В наши дни считающаяся роскошью, эта ваза была стандартом того времени, с двумя ручками, тонким горлышком и узорами в виде заострённых листьев.";

        englishTexts["Ded"] = "War Hero";
        russianTexts["Ded"] = "Герой-военный";

        englishTexts["DedTxt"] = "They say he was a man of few words, inexpressive, with an oval face and an aquiline nose, tall of height. He got a medal for his services at the front, and wore it on his chest every day until he died.";
        russianTexts["DedTxt"] = "О нём говорили как о мужчине невыразительном, скупым на слова, с овальным лицом и орлиным носом, высокого роста. Он получил медаль за свои заслуги на фронте и носил её на груди неизменно до самой смерти.";

        englishTexts["Watch"] = "Decorative hourglass";
        russianTexts["Watch"] = "Песочные часы";

        englishTexts["WatchTxt"] = "It was a small statuette, the size of a palm, with black volcanic sand inside. It was brought from abroad, and although it underwent many shipments over rocky terrain, it was not damaged due to the shatterproof glass at its base.";
        russianTexts["WatchTxt"] = "Это была небольшая статуэтка, размером с ладонь, с чёрным вулканическим песком внутри. Привезена из-за рубежа, и хотя претерпела множество перевозок по каменистой местности, не была повреждена за счёт небьющегося стекла в её основании.";

        englishTexts[""] = "";
        russianTexts[""] = "";

        englishTexts[""] = "";
        russianTexts[""] = "";

        englishTexts[""] = "";
        russianTexts[""] = "";
    }

    public string GetText(string key)
    {
        if (currentLanguage == Language.Russian && russianTexts.ContainsKey(key))
            return russianTexts[key];
        if (currentLanguage == Language.English && englishTexts.ContainsKey(key))
            return englishTexts[key];

        return key;
    }

    public void SetLanguage(Language newLang)
    {
        currentLanguage = newLang;
        PlayerPrefs.SetInt("Language", (int)newLang);
        PlayerPrefs.Save();

        LocalizedText[] texts = FindObjectsOfType<LocalizedText>();
        foreach (var t in texts)
            t.UpdateText();
    }

    void LoadSavedLanguage()
    {
        int savedLang = PlayerPrefs.GetInt("Language", 0);
        currentLanguage = (Language)savedLang;
    }
}