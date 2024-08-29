using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Threading.Tasks;

namespace Algo
{
    public class MergeSort : MonoBehaviour
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
            await SortRoutine(GenerateBars._Instance.BarValues,0,GenerateBars._Instance.BarValues.Count-1);
        }
        private async Task SortRoutine(List<Bar> arr, int low, int high)
        {

            if (low >= high) return;

            int mid = ( low+high) / 2;

            await SortRoutine(arr, low, mid);
            await SortRoutine(arr, mid + 1, high);

            await Merge(arr, low, mid, high);

        }

        async Task Merge(List<Bar> arr, int low, int mid, int high)
        {
            int left = low;
            int right = mid + 1;

            List<int> temp = new List<int>();

            while ((left <= mid) && (right <= high))
            {

                if (arr[left]._Value <= arr[right]._Value)
                {
                    temp.Add(arr[left]._Value);
                    left++;
                }
                else
                {
                    temp.Add(arr[right]._Value);
                    right++;
                }
            }

            while ((left <= mid))
            {
                temp.Add(arr[left]._Value);
                left++;
            }

            while (right <= high)
            {
                temp.Add(arr[right]._Value);
                right++;
            }


            for (int i = low; i <= high; i++)
            {
                arr[i]._Value = temp[i - low];
                await Task.Delay(1);
            }
        }


    }
}