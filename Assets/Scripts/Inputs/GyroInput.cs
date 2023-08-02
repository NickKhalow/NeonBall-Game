using UnityEngine;

namespace Inputs
{
    public class GyroInput : AbstractInput
    {
        public override Vector2 Direction()
        {
            var raw = Input.acceleration;
            return new Vector2(raw.x, -raw.z);
        }
    }
}