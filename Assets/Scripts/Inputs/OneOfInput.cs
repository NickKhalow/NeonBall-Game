using UnityEngine;

namespace Inputs
{
    public class OneOfInput : AbstractInput
    {
        [SerializeField] private AbstractInput[] inputs;

        public override Vector2 Direction()
        {
            var max = Vector2.zero;

            foreach (var input in inputs)
            {
                var current = input.Direction();
                if (current.magnitude > max.magnitude)
                {
                    max = current;
                }
            }

            return max;
        }
    }
}