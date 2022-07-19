using TMPro;
using UnityEngine;

namespace Game.Hp.View
{
    public class SimpleHpView : MonoBehaviour, IHealthView
    {
        [SerializeField] private TMP_Text _text;
        
        public void UpdateView(float amount)
        {
            _text.text = amount.ToString();
        }
    }
}