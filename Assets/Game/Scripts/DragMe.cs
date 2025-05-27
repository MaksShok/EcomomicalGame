using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Scripts
{
    public class DragMe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private float _increaseRatio;
        
        private Vector3 offset;

        public void OnBeginDrag(PointerEventData eventData)
        {
            transform.localScale += new Vector3(_increaseRatio, _increaseRatio, 0);

            Vector3 mousePos = Input.mousePosition;
            offset = gameObject.transform.position - Camera.main
                .ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(
                new Vector3(mousePos.x, mousePos.y, 0)) + offset;
            
            transform.position = newPosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.localScale = new Vector3(1, 1, 0);
            Debug.Log("11111");
        }
    }
}