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

        englishTexts["Hand"] = "At the time of the Migration, people carried with them the symbols of the four-legged bird-god, the patron of luck and good news. They thought that with his blessing a long road through a near-impenetrable forest could be made easier, become shorter and less dangerous.";
        russianTexts["Hand"] = "�� ������� ����������� ���� ������ � ����� ������� ������������ ��������-�����, ����������� ����� � ������� ��������. ��� �������, ��� � ��� �������������� ������ ���� ����� ����� ��� ������������ ��� ��� �� ���� ��������, ���� �� ������ ��� ����� ������.";

        englishTexts["Kr"] = "The vatrushkas are depleating steadily...";
        russianTexts["Kr"] = "�������� ���������� ��������������";

        englishTexts["Red"] = "The works of this author were widely known thanks to the use of bright colors, ornate patterns, and the attention to detail. Unfortunately, many of her later collections, characterized by their large size, were lost or damaged during the Migration.";
        russianTexts["Red"] = "������ ������� ������ ���� �������� ������ �������� ��������� ����� ����� ��������, ���������� ������, � �������� � �������. � ���������, ������ �� � ����� ������� ���������, ����������������� ����� ������� ��������, ���� ������� ��� ���������� �� ���� �����������.";

        englishTexts["Bird"] = "Statuette of bird-god";
        russianTexts["Bird"] = "��������� ��������-�����";

        englishTexts["BirdTxt"] = "Any icons, statues, or any other depictions of the bird-god were strictly regulated, underwent a comparison to the existing Texts and the accepted standards.";
        russianTexts["BirdTxt"] = "����� �����, ������, � ���� ����������� ��������-����� ������ ��������������, ����������� ������������� �� � ������������� �������� � ��������� �������.";

        englishTexts["Mir"] = "Golden mirror";
        russianTexts["Mir"] = "������� �������";

        englishTexts["MirTxt"] = "A hand mirror made of pure gold. Before the Migration it could�ve been used in everyday life by common people, although many would prefer mirrors made of lighter materials.";
        russianTexts["MirTxt"] = "������ �������������� �� ������� ������. �� ����������� ����� �������������� � ���� ��������������, ���� ������ ��������� �� ������� �� ����� ����� �� ���� ����������.";

        englishTexts["Rad"] = "Old radio";
        russianTexts["Rad"] = "������ �����";

        englishTexts["RadTxt"] = "In those times a lot of household items were made by small subsidiaries under the name of the parent company. Even though now the production is recovering, it cannot meet the demand, and to this day the same appliances and furniture are used as were back then.";
        russianTexts["RadTxt"] = "� �� ��� ������ ������� �������� ���������� ���������� ��������� ���������� ��� ������������� ������������. ���� ������ ������������ �����������������, ��� ���������� ������������� ���� �����, � �� ��� ��� ������������ �� �� ������� � ���������, ��� �������������� �����.";

        englishTexts["Photo"] = "Photo of the Migration";
        russianTexts["Photo"] = "���������� �����������";

        englishTexts["PhotoTxt"] = "People migrated together with their families, taking everything they could. Because of the terrain of the path, a lot of things had to be left behind.";
        russianTexts["PhotoTxt"] = "���� ������� �������, ������� ��, ��� �����. ��-�� ������� ���������, ����� ������� �������� �� ����, ������ ���� �������� �������� ������.";

        englishTexts["Gazeta"] = "Local Museum Hires a Genius!";
        russianTexts["Gazeta"] = "������� ����� �������� �����!";

        englishTexts["GazetaTxt"] = "Multitudes of antiques were sorted, scams and authentic pieces separated, things thought lost to time returned to their shelves, all thanks to the new hire! A grandson of a famous artifact collector, he seems to have indeed inherited her passion and talent for all things history...";
        russianTexts["GazetaTxt"] = "��������� ������������ ���� ��������������, �������� �������� �� �����������, ����, ����������� �����������, ��������� �� ���� ����� � � �� ��� ��������� ������ ����������! ���� ���������� ������������� ����������, ��, ������, ������������� ����������� � ������� � ������ �� �����, ��� ������� � ��������...";

        englishTexts["Close"] = "Close";
        russianTexts["Close"] = "�������";

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