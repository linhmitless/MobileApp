using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Week2.Models
{
    public enum AttributeEnum
    {
        // Not specified
        Unknown = 0,

        // The speed of the character, impacts movement, and initiative
        Speed = 3,

        // The defense score, to be used for defending against attacks
        Defense = 2,

        // The Strength score determines attack power
        Strength = 4,

        // The Wisdom score determines the ability to visit Home Warren and rest

        Wisdom = 5,
        // Current Health which is always at or below MaxHealth
        CurrentHealth = 19,

        // The highest value health can go
        MaxHealth = 25,
    }

    // Helper functions for the AttribureList
    public static class AttributeList
    {

        // Returns a list of strings of the enum for Attribute
        // Removes the attributes that are not changable by Items such as Unknown, MaxHealth
        public static List<string> GetListItem
        {
            get
            {
                var myList = Enum.GetNames(typeof(AttributeEnum)).ToList();
                var myReturn = myList;
                return myReturn;
            }
        }

        // Returns a list of strings of the enum for Attribute
        // Removes the unknown
        public static List<string> GetListCharacter
        {
            get
            {
                var myList = Enum.GetNames(typeof(AttributeEnum)).ToList();
                var myReturn = myList;
                return myReturn;
            }
        }

        // Given the String for an enum, return its value.  That allows for the enums to be numbered 2,4,6 rather than 1,2,3
        public static AttributeEnum ConvertStringToEnum(string value)
        {
            return (AttributeEnum)Enum.Parse(typeof(AttributeEnum), value);
        }
    }
}