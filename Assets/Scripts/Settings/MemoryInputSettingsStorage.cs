using UnityEngine;
using UnityEngine.Serialization;

namespace Settings
{
    public class MemoryInputSettingsStorage : AbstractInputSettingsStorage
    {
        [FormerlySerializedAs("active")] [SerializeField] private ActiveInput activeInput = ActiveInput.Joystick;

        public override void Select(ActiveInput select)
        {
            activeInput = select;
        }

        public override ActiveInput Current()
        {
            return activeInput;
        }
    }
}