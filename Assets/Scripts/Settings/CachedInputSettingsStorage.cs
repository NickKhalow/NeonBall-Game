using System;
using Extensions;
using UnityEngine;

namespace Settings
{
    public class CachedInputSettingsStorage : AbstractInputSettingsStorage
    {
        [SerializeField] private AbstractInputSettingsStorage origin;
        private Active? current;

        private void Awake()
        {
            origin.EnsureNotNull("Storage is not specified");
        }

        public override void Select(Active select)
        {
            origin.Select(select);
            current = select;
        }

        public override Active Current()
        {
            if (current.HasValue == false)
            {
                current = origin.Current();
            }

            return current.Value;
        }
    }
}