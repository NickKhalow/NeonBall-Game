using UnityEngine;

namespace Settings
{
    public abstract class AbstractInputSettingsStorage : MonoBehaviour
    {
        public abstract void Select(Active select);

        public abstract Active Current();
    }
}