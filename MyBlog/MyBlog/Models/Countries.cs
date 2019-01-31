using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class Countries : List<String>
    {
        private Countries() : base()
        { }

        private static Countries _this;
        public static Countries Instance
        {
            get
            {
                if (_this == null)
                {
                    _this = new Countries();
                    _this.AddRange(new[]
                    {
                        "Ukraine",
                        "Nortrend",
                        "Zenonia"
                    });
                }
                return _this;
            }
        }
    }
}