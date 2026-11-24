using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

namespace BehaviorTree
{

    public class BlackBoardTEst
    {
        private Dictionary<string, object> _data = new();

        public bool TryGetValue<T>(string Query , ref T Result)
        {
            if (!_data.ContainsKey(Query)) return false;
            try
            {
            Result = (T)_data[Query];
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }            

        public void SetValue<T> (string Key , ref T Value)
        {
            if (!_data.ContainsKey(Key)) _data.Add(Key, Value);
            else _data[Key] = Value;
        }

        public void ClearValue<T>(string Key)
        {
            if (_data.ContainsKey(Key)) _data.Remove(Key);
        }

    }


}