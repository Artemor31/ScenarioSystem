using Assets.SimpleLocalization;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIStatusLocalization : MonoBehaviour
{
    [Serializable]
    private struct UIStatusByName
    {
        public string name;
        public string key;
    }

    [SerializeField] private UIStatusByName[] settings;
    private static Dictionary<string, string> values;

    public static string Localize(string name)
    {
        return LocalizationManager.Localize(values[name]);
    }

    private void Awake()
    {
        values = new Dictionary<string, string>();

        foreach (var value in settings)
        {
            values.Add(value.name, value.key);
        }
    }
}