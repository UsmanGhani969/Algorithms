using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


namespace Algo
{
    public class SelectionSort : MonoBehaviour
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
            for (int i = 0; i < n - 1; i++)
            {
                int MinIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (_list[j]._Value < _list[MinIndex]._Value)
                    {
                        MinIndex = j;
                    }
                }

                int temp = _list[MinIndex]._Value;
                _list[MinIndex]._Value = _list[i]._Value;
                _list[i]._Value = temp;

                await Task.Delay(1);
            }

        }
    }
}