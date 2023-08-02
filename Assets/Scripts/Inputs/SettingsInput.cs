using System;
using UnityEngine;

namespace Inputs
{
    public class SettingsInput : AbstractInput
    {
        
        [SerializeField] private AbstractInput gyro;
        [SerializeField] private AbstractInput joystick;
        [SerializeField] private Active active = Active.Joystick;

        public override Vector2 Direction() => active switch
        {
            Active.Gyro => gyro.Direction(),
            Active.Joystick => joystick.Direction(),
            _ => throw new ArgumentOutOfRangeException()
        };

        public void Select(Active select)
        {
            active = select;
        }

        public Active Current()
        {
            return active;
        }

        public enum Active
        {
            Gyro,
            Joystick
        }
    }
}