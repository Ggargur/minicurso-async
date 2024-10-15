using Minicurso.Movement.Interfaces;
using Minicurso.Tests;
using UnityEngine;

namespace Minicurso.Movement
{
    public class BaseMovement : MonoBehaviour, IMoveable
    {
        public float Speed { get => _speed; set => _speed = value; }
        public Vector3 Direction { get => _direction; set => _direction = value; }
        public float Amplitude { get => _amplitude; set => _amplitude = value; }

        [SerializeField] protected Vector3 _direction = Vector2.up;
        [SerializeField] protected float _speed = 1f;
        [SerializeField] protected float _amplitude = 1f;

        private Vector3 _startPosition;

        protected virtual void Start()
        {
            _startPosition = transform.position;
        }

        protected virtual void Update()
        {
            Move();
        }

        public virtual void Move()
        {
            DoHeavyCalculations();
            SetNewPosition();
        }

        protected void SetNewPosition() =>
            transform.position = _startPosition + _amplitude * Mathf.Sin(Time.time * Speed) * _direction;

        #region  Heavy Code
        public virtual void DoHeavyCalculations()
        {
            Fibonacci(TestManager.Instance.Intensity);
        }

        private int Fibonacci(int n)
        {
            if (n == 0 || n == 1) return n;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        #endregion
    }
}