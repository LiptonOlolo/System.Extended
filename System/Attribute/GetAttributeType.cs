namespace System
{
    /// <summary>
    /// Определяет тип поиска атрибута.
    /// </summary>
    public enum GetAttributeType
    {
        /// <summary>
        /// Получить атрибут класса.
        /// </summary>
        Class,

        /// <summary>
        /// Получить атрибут поля.
        /// </summary>
        Field,

        /// <summary>
        /// Получить атрибут свойства.
        /// </summary>
        Property,

        /// <summary>
        /// Получить атрибут метода.
        /// </summary>
        Method
    }
}
