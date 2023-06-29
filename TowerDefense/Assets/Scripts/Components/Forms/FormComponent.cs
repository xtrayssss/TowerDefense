using UnityComponents.Windows;

namespace Components.Forms
{
    internal struct FormComponent<T> where T : BaseWindow
    {
        public T Form;
    }
}