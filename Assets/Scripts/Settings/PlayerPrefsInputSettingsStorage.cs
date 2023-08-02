using System;
using UnityEngine;

namespace Settings
{
    public class PlayerPrefsInputSettingsStorage : AbstractInputSettingsStorage
    {
        [SerializeField] private string keyInputSettings = nameof(keyInputSettings);
        [SerializeField] private ActiveInput defaultOption = ActiveInput.Joystick;

        public override void Select(ActiveInput select)
        {
            PlayerPrefs.SetString(keyInputSettings, select.ToString());
        }

        public override ActiveInput Current()
        {
            var raw = PlayerPrefs.GetString(keyInputSettings, string.Empty);
            if (string.IsNullOrWhiteSpace(raw))
            {
                return defaultOption;
            }

            if (Enum.TryParse<ActiveInput>(raw, out var result))
            {
                return result;
            }

            throw new Exception($"Cannot parse '{raw}'");
        }
    }
}