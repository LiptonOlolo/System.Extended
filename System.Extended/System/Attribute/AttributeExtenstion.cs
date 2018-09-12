using System.Linq;
using System.Reflection;

namespace System
{
    /// <summary>
    /// Getting attributes.
    /// <para/>
    /// Получение атрибутов.
    /// </summary>
    public static class AttributeExtenstion
    {
        /// <summary>
        /// Getting attribute from class, field, property, method.
        /// <para/>
        /// Получение атрибута у класса, поля, свойства или метода.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// Attribute type.
        /// <para/>
        /// Тип атрибута.
        /// </typeparam>
        /// 
        /// <param name="value">
        /// Object.
        /// <para/>
        /// Объект.
        /// </param>
        /// 
        /// <param name="name">
        /// Name field, property or method.
        /// <para/>
        /// If get a class attribute = null.
        /// <para/>
        /// Имя поля, свойства или метода.
        /// <para/>
        /// Если необходимо получить атрибут класса, то можно передать null.
        /// </param>
        /// 
        /// <param name="getType">
        /// Getting type: class, field, property or method.
        /// <para/>
        /// Тип получения: из класса, поля, свойства или метода.
        /// </param>
        /// 
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="MissingFieldException"/>
        /// <exception cref="MissingMemberException"/>
        /// <exception cref="MissingMethodException"/>
        /// <exception cref="InvalidOperationException"/>
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
                    info = type.GetField(name) ?? throw new MissingFieldException();
                    break;

                case GetAttributeType.Property:
                    info = type.GetProperty(name) ?? throw new MissingMemberException();
                    break;

                case GetAttributeType.Method:
                    info = type.GetMethod(name) ?? throw new MissingMethodException();
                    break;

                default: throw new InvalidOperationException();
            }

            return (T)info.GetCustomAttributes(typeof(T), false).FirstOrDefault();
        }
    }
}
