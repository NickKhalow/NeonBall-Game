using System;
using System.Linq;
using Extensions;
using Settings;
using TMPro;
using UnityEngine;

namespace Ui
{
    public class InputSettingsUi : MonoBehaviour
    {
        [SerializeField] private AbstractInputSettingsStorage inputSettingsStorage;
        [SerializeField] private TMP_Dropdown dropdown;

        private void Awake()
        {
            dropdown.EnsureNotNull("Dropdown is not specified");
            inputSettingsStorage.EnsureNotNull("InputSettingsStorage is not specified");
        }

        private void Start()
        {
            dropdown.ClearOptions();
            dropdown.AddOptions(Enum.GetNames(typeof(ActiveInput)).ToList());
            dropdown.SetValueWithoutNotify(
                dropdown
                    .options
                    .FindIndex(e => e.text == inputSettingsStorage.Current().ToString())
            );
            dropdown.RefreshShownValue();
            dropdown.onValueChanged.AddListener(e =>
                inputSettingsStorage.Select(
                    Enum.Parse<ActiveInput>(dropdown.options[e].text)
                )
            );
        }
    }
}