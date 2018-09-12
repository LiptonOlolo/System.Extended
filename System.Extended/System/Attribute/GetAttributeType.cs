namespace System
{
    /// <summary>
    /// Type of search.
    /// <para/>
    /// Определяет тип поиска атрибута.
    /// </summary>
    public enum GetAttributeType
    {
        /// <summary>
        /// Get attribute from class.
        /// <para/>
        /// Получить атрибут класса.
        /// </summary>
        Class,

        /// <summary>
        /// Get attribute from field. 
        /// <para/>
        /// Получить атрибут поля.
        /// </summary>
        Field,

        /// <summary>
        /// Get attribute from property.
        /// <para/>
        /// Получить атрибут свойства.
        /// </summary>
        Property,

        /// <summary>
        /// Get attribute from method.
        /// <para/>
        /// Получить атрибут метода.
        /// </summary>
        Method
    }
}
