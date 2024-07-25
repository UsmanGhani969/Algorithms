using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Algo
{
    public class BubbleSort : MonoBehaviour
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


        private void StartSort()
        {
            StartCoroutine(SortRoutine());
        }
        IEnumerator SortRoutine()
        {
            List<Bar> _list = GenerateBars._Instance.BarValues;

            int n = _list.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {

                    if (_list[j]._Value > _list[j + 1]._Value)
                    {
                        int temp = _list[j]._Value;
                        _list[j]._Value = _list[j + 1]._Value;
                        _list[j + 1]._Value = temp;

                        yield return new WaitForSeconds(0f);
                    }

                }
            }
        }
    }
}