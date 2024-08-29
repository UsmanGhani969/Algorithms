using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Algo
{
    public class QuickSort : MonoBehaviour
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

            List<int> dummyINts = new List<int>();
            foreach (var i in GenerateBars._Instance.BarValues)
            {
                dummyINts.Add(i._Value);
            }
            dummyINts.Add(9999);

            await Sort(dummyINts,0,dummyINts.Count-1);
        }
        private async Task Sort(List<int> list,int low,int high)
        {
            if(low<high)
            {
                int partitionIndex=await Partition(list,low,high);
                await Sort(list, low, partitionIndex);
                await Sort (list,partitionIndex+1,high);
            }
           

        }
        private async Task<int> Partition(List<int> _list,int low,int high)
        {
            int pivotElement = _list[low];

            int i = low;

            int j = high;

            do
            {
                do
                {
                    i++;
                } while (_list[i] <= pivotElement);

                do
                {
                    j--;
                } while (_list[j] > pivotElement);

                if (i < j)
                {
                   await Swap(_list,i, j);
                }

            } while (i<j);


            await Swap(_list, low, j);
            return j;
        }
        private async Task Swap(List<int> _list,int i,int j)
        {
            


            int temp = _list[i];
            _list[i] = _list[j];
            _list[j] = temp;

            GenerateBars._Instance.BarValues[i]._Value = _list[i];
            GenerateBars._Instance.BarValues[j]._Value = _list[j];
  
            await Task.Delay(1);
        }
    }
}