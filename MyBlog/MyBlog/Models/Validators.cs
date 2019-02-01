using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class CheckBoxItemsAttribute : ValidationAttribute
    {
        private IEnumerable<String> compareList;

        public CheckBoxItemsAttribute()
        {
            compareList = new String[0];
        }

        public CheckBoxItemsAttribute(String[] items) : this()
        {
            compareList = items;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;
            if (!(value is IEnumerable<String>)) return false;

            foreach(var checkBoxItem in value as IEnumerable<String>)
            {
                Boolean isItemValid = false;
                foreach (var compareItem in compareList)
                {
                    if (checkBoxItem.Equals(compareItem))
                    {
                        isItemValid=true;
                        break;
                    }
                }
                if (!isItemValid) return false;
            }

            return true;
        }
    }

    public class RadioItemsAttribute: ValidationAttribute
    {
        private IEnumerable<String> compareList;

        public RadioItemsAttribute()
        {
            compareList = new String[0];
        }

        public RadioItemsAttribute(String[] items):this()
        {
            compareList = items;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return false;

            foreach(var item in compareList)
            {
                if (value.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}