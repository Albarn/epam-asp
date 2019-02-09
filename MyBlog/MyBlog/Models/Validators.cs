using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    /// <summary>
    /// validate value from checkbox input
    /// </summary>
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

        /// <summary>
        /// check, that all value items
        /// are from compareList collection
        /// </summary>
        /// <param name="value">selected items</param>
        public override bool IsValid(object value)
        {
            //value must be enumerable
            if (value == null) return true;
            if (!(value is IEnumerable<String>)) return false;

            //validate that each item in value
            foreach(var checkBoxItem in value as IEnumerable<String>)
            {
                Boolean isItemValid = false;
                //is from compareList
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

    /// <summary>
    /// validate value from radio input
    /// </summary>
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

        /// <summary>
        /// check that value is from compareList
        /// </summary>
        /// <param name="value">selected item</param>
        public override bool IsValid(object value)
        {
            if (value == null) return false;

            foreach(var item in compareList)
            {
                //at least one item must be equal to value
                if (value.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}