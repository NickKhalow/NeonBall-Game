using UnityEngine;

namespace Settings
{
    public abstract class AbstractInputSettingsStorage : MonoBehaviour
    {
        public abstract void Select(ActiveInput select);

        public abstract ActiveInput Current();
    }
}