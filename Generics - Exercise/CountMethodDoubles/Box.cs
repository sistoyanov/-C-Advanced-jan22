using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace CountMethodDoubles
{
    public class Box<T> where T : IComparable<T>
    {
        //private List<T> list;
        //private static T comperer;
        public Box(T value)
        {
            Value = value;
        }
        //public Box(List<T> list, T comperer)
        //{
        //    this.list = list;
        //    Box<T>.comperer = comperer;
        //}

        public T Value { get; set; }

        public override string ToString()
        {
            return $"{Value.GetType()}: {Value}";
        }

        public int GetValuesGreaterThan<U>(List<T> inputList, T comperer) where U : IComparable<U>
        {
            return inputList.Count(item => item.CompareTo(comperer) > 0);
            this.Value.CompareTo(comperer);

            foreach (var item in inputList)
            {
                
            }
        }

        //public int CompareTo(T other) => comperer.CompareTo(other);

    }

    //public class Box<T> : IComparable<T> where T : IComparable<T>
    //{
    //    private T _data;
    //    private List<T> _list;
    //    private static T _element;
    //    public Box(T data)
    //    {
    //        _data = data;
    //    }

    //    public Box(List<T> list, T element)
    //    {
    //        _list = list;
    //        _element = element;
    //    }

    //    public override string ToString()
    //    {
    //        return $"{_data.GetType()}: {_data}";
    //    }

    //    public static int GetValuesGreaterThan<U>(List<U> inputList, U element) where U : IComparable<U>
    //    {
    //        return inputList.Count(item => item.CompareTo(element) > 0);
    //    }

    //    public int CompareTo(T other) => _element.CompareTo(other);

    //}

}
