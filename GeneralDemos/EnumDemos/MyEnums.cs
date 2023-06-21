using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.Serialization;

namespace EnumDemos
{
    public enum Status
    {
        [EnumMember(Value = "This is 'New' Enum Member Value")]
        [Description("New Document")]
        [Display(Name = "NEW")]
        New,
        [Description("Document WIP")]
        [Display(Name = "IN PROGRESS")]
        InProgress,
        [Description("Document Approved")]
        [Display(Name = "APPROVED")]
        Approved,
        [Description("Document Rejeced")]
        [Display(Name = "REJECTED")]
        Rejected
    }

    public static class MyEnums
    {
        public static string GetEnumDescription(Enum enumType)
        {
            FieldInfo fieldInfo = enumType.GetType().GetField(enumType.ToString());
            DescriptionAttribute[] attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }
            return enumType.ToString();
        }


        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()!
                .GetName()!;
        }

        public static string GetEnumMemberValue(this Enum enumValue)
        {
            //return enumValue.GetType()
            //    .GetMember(enumValue.ToString())
            //    .FirstOrDefault()
            //    .GetCustomAttribute<EnumMemberAttribute>()!.Value!;

            var member = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault();
            var attribute = member.GetCustomAttributes(false)
                .OfType<EnumMemberAttribute>()
                .FirstOrDefault();
            if (attribute != null)
            {
                return attribute.Value;
            }
            return null;

        }
    }
}
