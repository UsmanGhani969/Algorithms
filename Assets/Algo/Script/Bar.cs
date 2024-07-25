using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Algo
{
    public class Bar : MonoBehaviour
    {
        [SerializeField]
        private int Value;
        public int _Value 
        { 
            get 
            { 
                return  Value;
            } 
            set 
            { 
                Value = value;
                SetValue(Value);
            } 
        }

        private Image m_Bar;

        public void SetValue(int _value)
        {
            if (m_Bar == null)m_Bar = GetComponent<Image>();

            Value = _value;

            m_Bar.fillAmount = (Value / 1000f);
        }
    }
}