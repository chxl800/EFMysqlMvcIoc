using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Common.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// 获取成员元数据的Description特性描述信息
        /// </summary>
        /// <returns>返回Description特性描述信息，如不存在则返回成员的名称</returns>
        public static string ToDescription(this Enum value)
        {
            if(value == null)
                return string.Empty;
            Type type = value.GetType().GetNonNummableType();

            MemberInfo member = type.GetMember(value.ToString()).FirstOrDefault();
            return member != null ? member.ToDescription() : value.ToString();
        }


        /// <summary>
        /// 返回枚举的全部成员描述数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IList<string> ToDescriptions<T>() where T : struct
        {
            var type = typeof(T);
            var names = System.Enum.GetNames(type);

            return names.Select(item => {
                var member = type.GetMember(item).FirstOrDefault();
                return member != null ? member.ToDescription() : member.ToString();
            }).ToList();
        }

        /// <summary>
        /// 返回枚举描述名和name对应的字典
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IDictionary<string, string> ToDescriptionAndNames<T>() where T : struct
        {
            var type = typeof(T);
            var names = System.Enum.GetNames(type);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach(var value in names)
            {
                var member = type.GetMember(value).FirstOrDefault();
                var key = member != null ? member.ToDescription() : "";
                dict[key] = value;
            }
            return dict;
        }

        /// <summary>
        /// 获取枚举成员信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<EnumInfoItem> GetEnumInfo(this Type type)
        {
            if(!type.IsEnum)
            {
                throw new ArgumentException("type参数不属于枚举类型");
            }

            List<EnumInfoItem> enumInfos = new List<EnumInfoItem>();

            foreach(int val in Enum.GetValues(type))
            {
                string name = Enum.GetName(type, val);
                string description = type.GetMember(name).Single().ToDescription();

                enumInfos.Add(new EnumInfoItem()
                {
                    Name = name,
                    Value = val,
                    Description = description
                });
            }
            
            return enumInfos;
        }

    }

    public class EnumInfoItem
    {
        public string Name { get; set; }

        public int Value { get; set; }

        public string Description { get; set; }
    }
}