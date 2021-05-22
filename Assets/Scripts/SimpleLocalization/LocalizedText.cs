using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

namespace Assets.SimpleLocalization
{
	/// <summary>
	/// Localize text component.
	/// </summary>
    [RequireComponent(typeof(Text))]
    public class LocalizedText : MonoBehaviour
    {
        [SerializeField] string localizationKey;
        public string LocalizationKey
        {
            get 
            {
                return localizationKey;
            }
            set
            {
                localizationKey = value;
                Localize();
            }
        }

        private void Awake()
        {
            
        }

        Dictionary<string, string> KeysChange = new Dictionary<string, string>(0);
        public void Start()
        {
            KeysChange.Add("Return", "Enter");
            KeysChange.Add("Mouse0", "LMB");
            Localize();
            LocalizationManager.LocalizationChanged += Localize;
           
        }

        public void OnDestroy()
        {
            LocalizationManager.LocalizationChanged -= Localize;
        }

        public void Localize()
        {
            List<string> keyName = new List<string>(0);
            switch (LocalizationKey)
            { 
                case "Lessons1.3": keyName.Add("BatteryToggle"); break;
                case "Lessons1.5": keyName.Add("StartRecord"); break;
                case "Lessons1.10": keyName.Add("ChangeCam"); break;
                case "Lessons1.11": keyName.Add("ReverseChange"); break;
                case "Lessons1.14": keyName.Add("SpeedUP"); keyName.Add("SpeedDown"); break;
                case "Lessons1.16": keyName.Add("SelectLeftDoors"); keyName.Add("SelectRightDoors"); break;
                case "Lessons1.17": keyName.Add("DoorsClose"); break;
                case "Lessons1.18": keyName.Add("EventLeftDoors"); keyName.Add("EventRightDoors"); break;
                case "Lessons1.20": keyName.Add("DoorsClose"); break;
                case "Lessons1.24": keyName.Add("StartRecord"); keyName.Add("SelectLeftDoors"); keyName.Add("DoorsClose"); keyName.Add("EventLeftDoors"); break;
                case "Lessons1.25": keyName.Add("ChangeBrake"); break;
                case "Lessons1.27": keyName.Add("StopBraking"); break;

                case "Lessons2.2": keyName.Add("BatteryToggle"); keyName.Add("ReverseChange"); break;
                case "Lessons2.7": keyName.Add("ReverseChange"); break;
                case "Lessons2.8": keyName.Add("ChangeCab"); break;
                case "Lessons2.9": keyName.Add("ChangeCab"); break;
                case "Lessons2.10": keyName.Add("ExitAndEnterTrain"); break;
                case "Lessons2.11": keyName.Add("Mouse0"); break;
                case "Lessons2.13": keyName.Add("ExitAndEnterTrain"); break;
                case "Lessons2.14": keyName.Add("ReverseChange"); break;
                case "Lessons2.19": keyName.Add("StopBraking"); break;

                case "Lessons3.2": keyName.Add("Mouse0"); break;
                case "Lessons3.5": keyName.Add("Mouse0"); break;
                case "Lessons3.7": keyName.Add("Vigilance"); break;
                case "Lessons3.8": keyName.Add("ChangeCab"); break;
                case "Lessons3.19": keyName.Add("StopBraking"); break;
            }
            if (keyName.Count > 0)
            {
              //  keyName = keyName.Select(x => InputStorage.Singleton.GetKeyByName(x).KeyName).ToList();

                foreach (var i in KeysChange)
                {
                    for(int j = 0; j < keyName.Count; j++)
                    { 
                        if (i.Key == keyName[j]) keyName[j] = i.Value;
                    }
                }
                
                GetComponent<Text>().text = LocalizationManager.Localize(LocalizationKey, keyName.ToArray());
            }
            else GetComponent<Text>().text = LocalizationManager.Localize(LocalizationKey);
        }
    }
}