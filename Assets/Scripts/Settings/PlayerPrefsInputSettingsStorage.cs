using System;
using UnityEngine;

namespace Settings
{
    public class PlayerPrefsInputSettingsStorage : AbstractInputSettingsStorage
    {
        [SerializeField] private string keyInputSettings = nameof(keyInputSettings);
        [SerializeField] private Active defaultOption = Active.Joystick;

        public override void Select(Active select)
        {
            PlayerPrefs.SetString(keyInputSettings, select.ToString());
        }

        public override Active Current()
        {
            var raw = PlayerPrefs.GetString(keyInputSettings, string.Empty);
            if (string.IsNullOrWhiteSpace(raw))
            {
                return defaultOption;
            }

            if (Enum.TryParse<Active>(raw, out var result))
            {
                return result;
            }

            throw new Exception($"Cannot parse '{raw}'");
        }
    }
}