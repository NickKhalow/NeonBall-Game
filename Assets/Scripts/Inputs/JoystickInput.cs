using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Inputs
{
    public class JoystickInput : AbstractInput, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Transform knob;
        [SerializeField] private Vector2 start;
        [SerializeField] private Vector2 current;
        [SerializeField] private float maxAmplitude = 100;

        public override Vector2 Direction()
        {
            return (current - start) / maxAmplitude;
        }

        private void Awake()
        {
            knob.gameObject.SetActive(false);
        }

        public void OnDrag(PointerEventData eventData)
        {
            var distance = Vector2.Distance(start, eventData.position);
            if (distance > maxAmplitude)
            {
                var delta = (eventData.position - start).normalized * maxAmplitude;
                eventData.position = start + delta;
            }

            knob.position = current = eventData.position;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            knob.position = current = start = eventData.position;
            knob.gameObject.SetActive(true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            knob.gameObject.SetActive(false);
            knob.position = current = start = Vector2.zero;
        }
    }
}