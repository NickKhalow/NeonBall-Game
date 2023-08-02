using UnityEngine;

namespace Settings
{
    public class MemoryInputSettingsStorage : AbstractInputSettingsStorage
    {
        [SerializeField] private Active active = Active.Joystick;

        public override void Select(Active select)
        {
            active = select;
        }

        public override Active Current()
        {
            return active;
        }
    }
}