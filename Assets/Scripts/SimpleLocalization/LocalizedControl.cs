using UnityEngine;
using Assets.SimpleLocalization;

public class DictionaryLanguage
{
    public DictionaryLanguage(string shortName, SystemLanguageExtended language)
    {
        KeyShortName = shortName;
        ValueLanguage = language;
    }

    public string KeyShortName { get; set; }
    public SystemLanguageExtended ValueLanguage { get; set; }

    public override string ToString()
    {
        return ValueLanguage.ToString();
    }
}

public static class ReductionLanguage
{
    public static DictionaryLanguage[] list =
    {
            new DictionaryLanguage("en", SystemLanguageExtended.English),    // 0
            new DictionaryLanguage("ru", SystemLanguageExtended.Russian),    // 1
            new DictionaryLanguage("de", SystemLanguageExtended.German),     // 2
            new DictionaryLanguage("fr", SystemLanguageExtended.French),     // 3
            new DictionaryLanguage("br", SystemLanguageExtended.Portuguese), // 4
            new DictionaryLanguage("bz", SystemLanguageExtended.BrazilianPortuguese),     // 5
            new DictionaryLanguage("es", SystemLanguageExtended.Spanish),    // 6
            new DictionaryLanguage("it", SystemLanguageExtended.Italian),    // 7
            new DictionaryLanguage("ko", SystemLanguageExtended.Korean),     // 8
            new DictionaryLanguage("cz", SystemLanguageExtended.Czech),      // 9
            new DictionaryLanguage("tr", SystemLanguageExtended.Turkish),    // 10
            new DictionaryLanguage("cn", SystemLanguageExtended.Chinese),    // 11
            new DictionaryLanguage("cnt", SystemLanguageExtended.ChineseTraditional),     // 12
            new DictionaryLanguage("ro", SystemLanguageExtended.Romanian),   // 13
            new DictionaryLanguage("pl", SystemLanguageExtended.Polish),     // 14
    };

    public static string GetShortName(int index)
    {
        if (index < 0 || index >= list.Length)
            return "en";
        return list[index].KeyShortName;
    }

    public static SystemLanguageExtended GetLanguage(int index)
    {
        if (index < 0 || index >= list.Length)
            return SystemLanguageExtended.English;
        return list[index].ValueLanguage;
    }

    public static SystemLanguageExtended GetSystemLanguage(string key)
    {
        foreach (var item in list)
        {
            if (item.KeyShortName == key) return item.ValueLanguage;
        }
        return SystemLanguageExtended.English;
    }

    public static string GetShortName(SystemLanguageExtended language)
    {
        foreach (var item in list)
        {
            if (item.ValueLanguage == language) return item.KeyShortName;
        }
        return "en";
    }
}

public class LocalizedControl : MonoBehaviour
{
    private void Awake()
    {
       // var language = FileBasedPrefs.GetString("language");
       // SetLanguage(ReductionLanguage.GetSystemLanguage(language));
    }

    public static void SetLanguage(SystemLanguageExtended language)
    {
        Example example = FindObjectOfType<Example>();
        Debug.Log("Установлен язык " + language);
        example.SetLocalization(language.ToString());
        foreach (var item in FindObjectsOfType<LocalizedText>())
            item.Localize();
    }

    public static string GetLanguage()
    {
        return LocalizationManager.Language;
    }


    /// <summary>
    /// Получить текст по ключу из базы.
    /// </summary>
    /// <param name="localizationKey">Название ключа.</param>
    public static string GetText(string localizationKey)
    {
        return LocalizationManager.Localize(localizationKey);
    }

    /// <summary>
    ///  Получить текст по ключу из базы cо вставками объектов в определенные места фразы.
    /// </summary>
    /// <param name="localizationKey">Название ключа.</param>
    /// <param name="args">Объекты для вставки в текст.</param>
    public static string GetText(string localizationKey, params object[] args)
    {
        return LocalizationManager.Localize(localizationKey, args);
    }

    /// <summary>
    /// Получить текст по ключу из базы, принудительно присвоив язык.
    /// </summary>
    /// <param name="localizationKey">Название ключа.</param>
    /// <param name="sysLang">Язык.</param>
    public static string GetText(string localizationKey, SystemLanguage sysLang)
    {
        return LocalizationManager.Localize(localizationKey, sysLang.ToString());
    }

    /// <summary>
    /// Получить текст по ключу из базы cо вставками объектов в определенные места фразы, принудительно присвоив язык.
    /// </summary>
    /// <param name="localizationKey">Название ключа.</param>
    /// <param name="sysLang">Язык.</param>
    /// <param name="args">Объекты для вставки в текст.</param>
    public static string GetText(string localizationKey, SystemLanguage sysLang, params object[] args)
    {
        return LocalizationManager.Localize(localizationKey, sysLang.ToString(), args);
    }
}
