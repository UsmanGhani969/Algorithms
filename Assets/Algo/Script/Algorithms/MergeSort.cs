using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

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


        private void StartSort()
        {
            SortRoutine(GenerateBars._Instance.BarValues.ToArray(),0,GenerateBars._Instance.BarValues.Count-1);
        }
        private void SortRoutine(Bar[] arr, int low, int high)
        {

            if (low < high)
            {
                int mid = ( low+high) / 2;

                SortRoutine(arr, low, mid);
                SortRoutine(arr, mid + 1, high);

                Merge(arr, low, mid, high);
            }
        }


        private void Merge(Bar[] arr, int low, int mid, int high)
        {
            int i = low;
            int j = mid + 1;
            int k = low;

            Bar[] left = new Bar[mid-i+1];
            Bar[] right = new Bar[high-mid];

            Array.Copy(arr,low, left, 0, mid - i + 1); 
            Array.Copy(arr,mid+1, right, 0, high-mid);


            while ((i<=mid) && (j<=high))
            {

                if (left[i]._Value < right[j]._Value)
                {
                    arr[k]._Value = left[i]._Value;
                    k++;
                    i++;
                }
                else
                {
                    arr[k]._Value = right[j]._Value;
                    k++;
                    j++;
                }
            }


            for(;i<=mid;i++)
            {
                arr[k++]._Value = left[i]._Value;
            }

            for(;j<=high;j++)
            {
                arr[k++]._Value = right[j]._Value;
            }

        }
    }
}