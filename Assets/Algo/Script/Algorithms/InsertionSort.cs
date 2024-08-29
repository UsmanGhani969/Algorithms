using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Threading.Tasks;


namespace Algo
{
    public class InsertionSort : MonoBehaviour
    {
        [SerializeField]
        private Button m_SortBtn;




        private void OnEnable() => AddListeners();
        private void OnDisable() => RemoveListeners();
        private void AddListeners()
        {
            m_SortBtn.onClick.AddListener(StartSort);
        }
        private void RemoveListeners()
        {
            m_SortBtn.onClick.RemoveListener(StartSort);
        }


        private async void StartSort()
        {
            await Sort();
        }
        private async Task Sort()
        {
            List<Bar> _list = GenerateBars._Instance.BarValues;

            int n = _list.Count;
            for (int i = 1; i < n; ++i)
            {
                int key = _list[i]._Value;
                int j = i - 1;

                while (j >= 0 && _list[j]._Value > key)
                {
                    _list[j + 1]._Value = _list[j]._Value;
                    j = j - 1;
                }
                _list[j + 1]._Value = key;

                await Task.Delay(1);
            }
        }
    }
}