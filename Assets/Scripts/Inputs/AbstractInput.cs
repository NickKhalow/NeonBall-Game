using UnityEngine;

namespace Inputs
{
    public abstract class AbstractInput : MonoBehaviour
    {
        public abstract Vector2 Direction();
    }
}