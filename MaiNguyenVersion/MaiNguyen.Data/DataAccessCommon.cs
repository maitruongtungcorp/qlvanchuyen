using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel;
namespace MaiNguyen.Data
{
    /// <summary>
    /// Base data access component class.
    /// </summary>
    public abstract class DataAccessCommon
    {
        /// <summary>
        /// Hàm này nhằm mục đích trả về mảng giá trị của 1 entity dạng object[] - huytq14 17-08-14
        /// </summary>
        /// <param name="objEntity">1 Entity bất kỳ</param>
        /// <returns>Mảng các giá trị của 1 entity</returns>
        static public object[] Entity2ArrObjectValue(object objEntity)
        {
            List<object> lstObj = new List<object>();
            PropertyInfo[] propertyInfos = objEntity.GetType().GetProperties();// (BindingFlags.Public | BindingFlags.Static);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(objEntity.GetType());
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                if (propertyInfos[i].Name.ToLower() != "totalcount")
                    lstObj.Add(properties[i].GetValue(objEntity));
            }
            return lstObj.ToArray();
        }
        /// <summary>
        /// Hàm này nhằm mục đích trả về mảng giá trị của 1 entity dạng object[] - huytq14 17-08-14
        /// </summary>
        /// <param name="objEntity">1 Entity bất kỳ</param>
        /// <returns>Mảng các giá trị của 1 entity</returns>
        static public object[] Entity2ArrObjectValue(object objEntity, string NotMapColName)
        {
            List<object> lstObj = new List<object>();
            PropertyInfo[] propertyInfos = objEntity.GetType().GetProperties();// (BindingFlags.Public | BindingFlags.Static);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(objEntity.GetType());
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                if (propertyInfos[i].Name.ToLower() != "totalcount" && propertyInfos[i].Name.ToLower() != NotMapColName.ToLower())
                    lstObj.Add(properties[i].GetValue(objEntity));
            }
            return lstObj.ToArray();
        }
    }
}
