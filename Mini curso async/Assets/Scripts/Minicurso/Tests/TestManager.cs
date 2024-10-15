using System;
using System.Collections.Generic;
using Minicurso.Movement;
using UnityEngine;
using System.Linq;

namespace Minicurso.Tests
{
    public class TestManager : MonoBehaviour
    {
        #region Singleton
        public static TestManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<TestManager>();
                    if (_instance == null)
                        _instance = Resources.Load<TestManager>("Prefabs/Test Manager");
                }
                return _instance;
            }
        }


        private static TestManager _instance;
        #endregion

        public int Intensity { get => _lagIntensity; set => _lagIntensity = value; }
        [SerializeField] private GameObject _prefab;
        [SerializeField] private float _spacing = 1.5f;
        [SerializeField] private int _lagIntensity = 23;

        private List<GameObject> _testObjects = new();

        private void Awake()
        {
            if(_instance == null){
                _instance = this;
            }
            else{
                Destroy(this);
            }
        }


        public void Spawn<T>(int n) where T : BaseMovement
        {
            int spawned = 0;
            int squareSize = FindNearestPerfectSquare(n);
            for (int i = 0; i < squareSize; i++)
            {
                for (int j = 0; j < squareSize; j++, spawned++)
                {
                    if (spawned >= n) return;

                    GameObject go = GetNewObject(i, j);
                    go.AddComponent<T>();
                }
            }
        }

        public static int FindNearestPerfectSquare(int n)
        {
            int sqrt = (int)Math.Sqrt(n);

            int lowerSquare = sqrt * sqrt;
            int higherSquare = (sqrt + 1) * (sqrt + 1);

            return Math.Abs(lowerSquare - n) <= Math.Abs(higherSquare - n) ? sqrt : sqrt + 1;
        }

        private GameObject GetNewObject(int i, int j)
        {
            string goName = $"Object {i} {j}";
            GameObject go = _prefab != null ? Instantiate(_prefab) : new(goName);
            go.name = goName;
            go.transform.position = _spacing * new Vector3(i, 0, j);
            _testObjects.Add(go);
            return go;
        }

        public void Clear(){
            _testObjects.ForEach((x) => Destroy(x));
            _testObjects.Clear();
        }
    }
}