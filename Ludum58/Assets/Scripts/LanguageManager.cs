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

        englishTexts["Hand"] = "At the time of the Migration, people carried with them the symbols of the four-legged bird-god, the patron of luck and good news. They thought that with his blessing a long road through a near-impenetrable forest could be made easier, become shorter and less dangerous.";
        russianTexts["Hand"] = "Во времена Переселения люди носили с собой символы чётырёхногого божества-птицы, покровителя удачи и хороших новостей. Они считали, что с его благословением долгий путь через почти что непроходимый лес мог бы быть облегчен, стал бы короче или менее опасен.";

        englishTexts["Kr"] = "The vatrushkas are depleating steadily...";
        russianTexts["Kr"] = "Ватрушки потихоньку заканчивваются";

        englishTexts["Red"] = "The works of this author were widely known thanks to the use of bright colors, ornate patterns, and the attention to detail. Unfortunately, many of her later collections, characterized by their large size, were lost or damaged during the Migration.";
        russianTexts["Red"] = "Работы данного автора были довольно широко известны благодаря своим ярким красками, витиеватым узорам, и вниманию к деталям. К сожалению, многие из её более поздних коллекций, характеризующихся своим крупным размером, были утеряны или повреждены по мере Переселения.";

        englishTexts["Bird"] = "Statuette of bird-god";
        russianTexts["Bird"] = "Статуэтка божества-птицы";

        englishTexts["BirdTxt"] = "Any icons, statues, or any other depictions of the bird-god were strictly regulated, underwent a comparison to the existing Texts and the accepted standards.";
        russianTexts["BirdTxt"] = "Любые иконы, статуи, и иные изображения божества-птицы строго регулировались, проводилось сопоставление их с существующими Текстами и принятыми нормами.";

        englishTexts["Mir"] = "Golden mirror";
        russianTexts["Mir"] = "Золотое зеркало";

        englishTexts["MirTxt"] = "A hand mirror made of pure gold. Before the Migration it could’ve been used in everyday life by common people, although many would prefer mirrors made of lighter materials.";
        russianTexts["MirTxt"] = "Ручное приспособление из чистого золота. До Переселения могло использоваться в быту простонародьем, хотя многие предпочли бы зеркала из более лёгких по весу материалов.";

        englishTexts["Rad"] = "Old radio";
        russianTexts["Rad"] = "Старое радио";

        englishTexts["RadTxt"] = "In those times a lot of household items were made by small subsidiaries under the name of the parent company. Even though now the production is recovering, it cannot meet the demand, and to this day the same appliances and furniture are used as were back then.";
        russianTexts["RadTxt"] = "В те дни многие бытовые предметы издавались небольшими дочерними компаниями под наименованием родительской. Хотя сейчас производство восстанавливается, оно неспособно удовлетворить весь спрос, и до сих пор используются те же приборы и фурнитура, что использовались тогда.";

        englishTexts["Photo"] = "Photo of the Migration";
        russianTexts["Photo"] = "Фотография Переселения";

        englishTexts["PhotoTxt"] = "People migrated together with their families, taking everything they could. Because of the terrain of the path, a lot of things had to be left behind.";
        russianTexts["PhotoTxt"] = "Люди уезжали семьями, забирая всё, что можно. Из-за рельефа местности, через который проходил их путь, многие вещи пришлось оставить позади.";

        englishTexts["Gazeta"] = "Local Museum Hires a Genius!";
        russianTexts["Gazeta"] = "Местный музей нанимает гения!";

        englishTexts["GazetaTxt"] = "Multitudes of antiques were sorted, scams and authentic pieces separated, things thought lost to time returned to their shelves, all thanks to the new hire! A grandson of a famous artifact collector, he seems to have indeed inherited her passion and talent for all things history...";
        russianTexts["GazetaTxt"] = "Множество антиквариата было рассортировано, подделки отделены от подлинников, вещи, считавшиеся утраченными, вернулись на свои полки — и всё это благодаря новому сотруднику! Внук известного коллекционера артефактов, он, похоже, действительно унаследовал её страсть и талант ко всему, что связано с историей...";

        englishTexts["Close"] = "Close";
        russianTexts["Close"] = "Закрыть";

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