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
        russianTexts["play"] = "������";

        englishTexts["menu"] = "Menu";
        russianTexts["menu"] = "����";

        englishTexts["Author"] = "Authors";
        russianTexts["Author"] = "������";

        englishTexts["Language"] = "Language";
        russianTexts["Language"] = "����";

        englishTexts["Next"] = "Next";
        russianTexts["Next"] = "������";

        englishTexts["Win"] = "Win";
        russianTexts["Win"] = "������";

        englishTexts["Restart"] = "Restart";
        russianTexts["Restart"] = "������";

        englishTexts["Over"] = "Everyone guessed that you're not a specialist, you were fired.";
        russianTexts["Over"] = "��� ����������, ��� �� �� ����������, ���� �������.";

        englishTexts["Attempt"] = "Attempts:";
        russianTexts["Attempt"] = "�������:";

        englishTexts["Cont"] = "Continue";
        russianTexts["Cont"] = "������";

        englishTexts["Pause"] = "Pause";
        russianTexts["Pause"] = "�����";

        englishTexts["DecVaz"] = "Decorative Vase";
        russianTexts["DecVaz"] = "���� ������������";

        englishTexts["DecVazAbout"] = "Considered a luxury item these days, this vase used to be the standard of that time, with two handles, a thin neck, and patterns in the form of sharp leaves.";
        russianTexts["DecVazAbout"] = "� ���� ��� ����������� ��������, ��� ���� ���� ���������� ���� �������, � ����� �������, ������ ��������� � ������� � ���� ���������� �������.";

        englishTexts["Ded"] = "War Hero";
        russianTexts["Ded"] = "�����-�������";

        englishTexts["DedTxt"] = "They say he was a man of few words, inexpressive, with an oval face and an aquiline nose, tall of height. He got a medal for his services at the front, and wore it on his chest every day until he died.";
        russianTexts["DedTxt"] = "� �� �������� ��� � ������� ���������������, ������ �� �����, � �������� ����� � ������� �����, �������� �����. �� ������� ������ �� ���� ������� �� ������ � ����� � �� ����� ��������� �� ����� ������.";

        englishTexts["Watch"] = "Decorative hourglass";
        russianTexts["Watch"] = "�������� ����";

        englishTexts["WatchTxt"] = "It was a small statuette, the size of a palm, with black volcanic sand inside. It was brought from abroad, and although it underwent many shipments over rocky terrain, it was not damaged due to the shatterproof glass at its base.";
        russianTexts["WatchTxt"] = "��� ���� ��������� ���������, �������� � ������, � ������ ������������� ������ ������. ��������� ��-�� ������, � ���� ���������� ��������� ��������� �� ���������� ���������, �� ���� ���������� �� ���� ����������� ������ � � ���������.";

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