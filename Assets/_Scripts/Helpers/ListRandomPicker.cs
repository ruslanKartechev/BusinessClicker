using System.Collections.Generic;
namespace RuslanScripts.Helpers
{
    public class ListRandomPicker<T> where T : class
    {
        private T _prevItem;
        private List<T> _pickFromList;

        private List<T> _prevList;


        public ListRandomPicker(List<T> pickFrom)
        {
            _pickFromList = pickFrom;
            _prevItem = null;
            _prevList = new List<T>();
        }

        public void ReInit(List<T> pickFrom)
        {
            _pickFromList = pickFrom;
            _prevItem = null;
        }


        /// <summary>
        /// Returns Random item from list, that is not equal to previous chosen
        /// </summary>
        /// <returns></returns>
        public T GetRandomNoPrev()
        {
            if (_pickFromList.Count == 1)
                return _pickFromList[0];
            T result = _prevItem ;
            int i = 0;
            int maxIterations = 30;
            do
            {
                result = GetRandom();
                i++;

            } while (result == _prevItem && i < maxIterations);
            _prevItem = result;
            return result;
        }


        public T GetRandomNoPrevList(int count)
        {
            if (_prevList.Count >= count)
                RefreshPrevList();
            if (_pickFromList.Count == 1)
                return _pickFromList[0];
            T result = null;
            int i = 0;
            int maxIterations = 30;
            do
            {
                result = GetRandom();
                i++;

            } while (_prevList.Contains(result) && i < maxIterations);
            _prevList.Add(result);
      
            return result;

        }

        public void RefreshPrevList()
        {
            _prevList?.Clear();
        }

        public T GetRandom()
        {
            int randIndex = UnityEngine.Random.Range(0, _pickFromList.Count);
            return _pickFromList[randIndex];
        }
    }

}