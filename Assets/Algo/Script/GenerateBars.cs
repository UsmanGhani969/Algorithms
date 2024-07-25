using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Algo
{
    public class GenerateBars : MonoBehaviour
    {

        private static GenerateBars instance;
        public static GenerateBars _Instance { get { return instance; } }


        [Space()]
        [SerializeField]
        private TMP_InputField m_NoOfBarsField;

        [Space()]
        [SerializeField]
        private Button m_RandomizeBtn;
        [SerializeField]
        private Button m_DecendingBtn;
        [SerializeField]
        private Button m_ClearBtn;

        [Space()]
        [SerializeField]
        private Transform m_Content;


        [SerializeField]
        private GameObject m_BarPrefab;



        [SerializeField]
        private List<Bar> m_BarValues = new List<Bar>();
        public List<Bar> BarValues { get {  return m_BarValues; } }



        private void Awake()
        {
            if(instance!=this || instance==null)instance = this;
        }

        private void OnEnable() => AddListeners();
        private void OnDisable() => RemoveListeners();
        private void AddListeners()
        {
            m_RandomizeBtn.onClick.AddListener(OnRandomizeClicked);
            m_DecendingBtn.onClick.AddListener(OnDecendingClicked);

            m_ClearBtn.onClick.AddListener(OnClearClicked);
        }
        private void RemoveListeners()
        {
            m_RandomizeBtn.onClick.RemoveListener(OnRandomizeClicked);
            m_DecendingBtn.onClick.RemoveListener(OnDecendingClicked);

            m_ClearBtn.onClick.RemoveListener(OnClearClicked);
        }




        private void OnClearClicked()
        {
            Clear();
        }

        private bool Validation()
        {
            if (string.IsNullOrEmpty(m_NoOfBarsField.text.Trim())) return false;
            return true;
        }

        private void Clear()
        {
            for(int i = 0;i < m_Content.childCount;i++)
            {
                Destroy(m_Content.GetChild(i).gameObject);
            }

            m_BarValues.Clear();
        }


        /// <summary>
        /// Randomize 
        /// </summary>
        private void OnRandomizeClicked()
        {
            if (!Validation()) return;

            Clear();

            int _noOfBars = Convert.ToInt32(m_NoOfBarsField.text.Trim());


            for (int i = 0; i < _noOfBars; i++)
            {
                GameObject _bar = Instantiate(m_BarPrefab);

                int rand = UnityEngine.Random.Range(0, 1000);

                Bar bar = _bar.GetComponent<Bar>();

                bar.SetValue(rand);

                _bar.transform.SetParent(m_Content);

                _bar.transform.localScale = Vector2.one;

                m_BarValues.Add(bar);
            }

        }
        /// <summary>
        /// Decending Order
        /// </summary>
        private void OnDecendingClicked()
        {
            if (!Validation()) return;

            Clear();

            int _noOfBars = Convert.ToInt32(m_NoOfBarsField.text.Trim());


            List<int> randValues= new List<int>();
            for (int i = 0; i < _noOfBars; i++)
            {
                randValues.Add(UnityEngine.Random.Range(0,1000));
            }

            randValues = randValues.OrderByDescending(x => x).ToList();


            for (int i = 0; i < _noOfBars; i++)
            {
                GameObject _bar = Instantiate(m_BarPrefab);

                int value = randValues[i];

                Bar bar = _bar.GetComponent<Bar>();

                bar.SetValue(value);

                _bar.transform.SetParent(m_Content);

                _bar.transform.localScale = Vector2.one;

                m_BarValues.Add(bar);
            }

        }


    }
}