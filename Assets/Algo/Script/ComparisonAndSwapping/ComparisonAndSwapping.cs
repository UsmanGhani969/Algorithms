using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Algo
{
    public class ComparisonAndSwapping : MonoBehaviour
    {


        [SerializeField]
        private TextMeshProUGUI m_AlgoInfo;


        private void OnEnable() => AddListeners();
        private void OnDisable() => RemoveListeners();
        private void AddListeners()
        {
            EventManger.ALGOINFO += SetAlgoInfo;
        }
        private void RemoveListeners()
        {
            EventManger.ALGOINFO -= SetAlgoInfo;
        }


        private void SetAlgoInfo(int _noOfComparison,int _noOfSwapping)
        {
            m_AlgoInfo.text = "No. of Comparisons =" + _noOfComparison + "\n No. of Swapping =" + _noOfSwapping;
        }
    }
}