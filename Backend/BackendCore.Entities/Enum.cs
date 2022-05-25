using System;
using BackendCore.Entities.Enum;

namespace BackendCore.Entities.Enum
{
  



    public enum AuditType
    {
        None = 0,
        Create = 1,
        Update = 2,
        Delete = 3
    }




    internal class Values : Attribute
    {
        public string NameEn;
        public string NameAr;
        public string Code;
        public Values(string nameEn, string nameAr, string code)
        {
            NameAr = nameAr;
            NameEn = nameEn;
            Code = code;
        }
    }
}
public static class Extensions
{
    public static EnumResult GetName(this Enum e)
    {
        var type = e.GetType();

        var memInfo = type.GetMember(e.ToString());

        if (memInfo.Length > 0)
        {
            var attrs = memInfo[0].GetCustomAttributes(typeof(Values), false);
            if (attrs.Length > 0)
            {
                var attributes = (Values)attrs[0];
                return new EnumResult
                {
                    Id = Convert.ToInt32(e),
                    NameEn = attributes.NameEn,
                    NameAr = attributes.NameAr,
                    Code = attributes.Code
                };
            }
        }

        throw new ArgumentException("Name " + e + " has no Name defined!");
    }
}

public class EnumResult
{
    public int Id { get; set; }
    public string NameEn { get; set; }
    public string NameAr { get; set; }
    public string Code { get; set; }
}

