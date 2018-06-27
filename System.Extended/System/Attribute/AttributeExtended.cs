using System.Linq;
using System.Reflection;

namespace System
{
    /// <summary>
    /// Получение атрибутов объекта.
    /// </summary>
    public static class AttributeExtended
    {
        /// <summary>
        /// Получение атрибута у класса, поля, свойства или метода..
        /// </summary>
        /// <typeparam name="T">Тип атрибута.</typeparam>
        /// <param name="value">Объект.</param>
        /// <param name="name">
        /// Имя поля, свойства или метода, из которого необходимо получить атрибут.
        /// Если необходимо получить атрибут класса, то можно передать null.
        /// </param>
        /// <param name="getType">Тип получения атрибута, из класса, поля, свойства или метода.</param>
        /// <returns></returns>
        public static T GetAttribute<T>(this object value, string name, GetAttributeType getType) where T : Attribute
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (name == null && getType != GetAttributeType.Class)
                throw new ArgumentNullException(nameof(name));

            var type = value.GetType();

            MemberInfo info = null;

            switch (getType)
            {
                case GetAttributeType.Class:
                    info = type;
                    break;

                case GetAttributeType.Field:
                    info = type.GetField(name);
                    break;

                case GetAttributeType.Property:
                    info = type.GetProperty(name);
                    break;

                case GetAttributeType.Method:
                    info = type.GetMethod(name);
                    break;
            }

            return (T)info.GetCustomAttributes(typeof(T), false).FirstOrDefault();
        }
    }
}
