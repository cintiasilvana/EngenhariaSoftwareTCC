
using System;

namespace TCC.Domain.Entities
{
    public abstract class BaseEntity
    {
        #region Constants   
        public const int MAX_LENGTH_CNPJ = 14;
        public const int MAX_LENGTH_RG = 10;
        public const int MAX_LENGTH_CLIENT_NAME = 50;
        public const int MAX_LENGTH_FANTASY_NAME = 50;
        public const int MAX_LENGTH_SOCIALREASON = 50;
        public const int MAX_LENGTH_NOTE = 250;

        #endregion

        #region Properties

        public int Id { get; set; }
      
        public int IdUsuario { get; set; }

        public DateTime? DataRegistro { get; set; }

        public DateTime? DataExclusao { get; set; }       
     
        #endregion
    }
    public static class Methods
    {
        public static void ToPropertyUpper<T>(this T _class)
            where T : class
        {
            //Type _type = _class.GetType();
            //System.Reflection.PropertyInfo[] _propertyInfos = _type.GetProperties();
            //string email = "@";
            //foreach (System.Reflection.PropertyInfo _propertyInfo in _propertyInfos)
            //{
            //    if (_propertyInfo.PropertyType.Name.ToLower().Equals("string"))
            //    {
            //        if (!string.IsNullOrEmpty((string)_propertyInfo.GetValue(_class)))
            //        {
            //            if (!((string)_propertyInfo.GetValue(_class)).Contains(email))
            //                _propertyInfo.SetValue(_class, ((string)_propertyInfo.GetValue(_class)).ToUpper());
            //            else
            //                _propertyInfo.SetValue(_class, ((string)_propertyInfo.GetValue(_class)).ToLower());
            //        }
            //    }
            //}
        }
    }
}
