using UnityEngine;

namespace Inputs
{
    public class KeyboardInput : AbstractInput
    {
        public override Vector2 Direction() => new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}