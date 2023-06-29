using UnityEngine;

namespace UnityComponents.Windows
{
    internal class BaseWindow : MonoBehaviour
    {
        public virtual void Open() => 
            gameObject.SetActive(true);

        public virtual void Close() => 
            gameObject.SetActive(false);

        public virtual void Move(Vector2 position)
        {
            gameObject.transform.position = position; 
            gameObject.SetActive(true);
        }
    }
}