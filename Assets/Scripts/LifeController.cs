using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{

    public class LifeController : MonoBehaviour
    {
        [SerializeField] private int _currentHp = 20;
        [SerializeField] private int _maxHp = 20;
        [SerializeField] private bool _fullHpOnAwake = true;
        [SerializeField] private UnityEvent<int, int> _onHpChanged;
        [SerializeField] private UnityEvent _onDeath;
        void Awake()
        {
            if (_fullHpOnAwake)
            {
                SetHp(_maxHp);
            }
        }

        public int CurrentHp => _currentHp;

        void SetHp(int hp)
        {
            int oldHp = _currentHp;

            hp = Mathf.Clamp(hp, 0, _maxHp);
            _currentHp = hp;

            if (oldHp != _currentHp)
            {
                _onHpChanged?.Invoke(_currentHp, _maxHp);

                if (_currentHp == 0)
                {
                    _onDeath?.Invoke();
                }
            }
        }

        public void AddHp(int amount)
        {
            SetHp(_currentHp + amount);
        }
    }
}
