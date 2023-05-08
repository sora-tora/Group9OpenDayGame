using UnityEngine;

namespace Minigames.Logan.Minigame1
{
    public class LK_PlayerHand : MonoBehaviour
    {
        private GameObject _currentItem;
        public GameObject CurrentItem
        {
            get { return _currentItem; }
            private set { _currentItem = value; }
        }

        public GameObject TakeItem()
        {
            if (_currentItem == null)
            {
                Debug.LogWarning("Player is not holding anything");
                return null;
            }
            _currentItem.transform.parent = null;
            _currentItem.transform.localRotation = Quaternion.identity;
            _currentItem.transform.localScale = Vector3.one;

            GameObject returnObj = _currentItem.transform.gameObject;
            _currentItem = null;

            return returnObj;
        }

        public void GiveItem(GameObject item)
        {
            if (_currentItem != null)
            {
                Debug.LogWarning("Player is holding item already, Dropping item");
                TakeItem();
            }
            _currentItem = item;
            _currentItem.transform.parent = transform;
            _currentItem.transform.localRotation = Quaternion.identity;
            _currentItem.transform.localPosition = Vector3.zero;
            _currentItem.transform.localScale = Vector3.one;

            return;
        }

        public bool IsHoldingItem()
        {
            return (_currentItem != null );
        }
    }
}