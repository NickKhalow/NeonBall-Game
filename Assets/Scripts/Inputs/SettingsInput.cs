using System;
using Extensions;
using Settings;
using UnityEngine;

namespace Inputs
{
    public class SettingsInput : AbstractInput
    {
        
        [SerializeField] private AbstractInput gyro;
        [SerializeField] private AbstractInput joystick;
        [SerializeField] private AbstractInputSettingsStorage inputSettingsStorage;

        private void Awake()
        {
            gyro.EnsureNotNull(nameof(gyro));
            joystick.EnsureNotNull(nameof(joystick));
            inputSettingsStorage.EnsureNotNull(nameof(inputSettingsStorage));
        }

        public override Vector2 Direction() => inputSettingsStorage.Current() switch
        {
            Active.Gyro => gyro.Direction(),
            Active.Joystick => joystick.Direction(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}