using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace com.elselam.runtimetest
{
    public class AssertMonoBehaviour : MonoBehaviour
    {
        [SerializeField] private Text _testName;
        [Space(10)]
        [SerializeField] private GameObject _assertPrefab;
        [SerializeField] private ScrollRect _assertsScroll;
    
        [SerializeField] private GameObject _successIndicator;
        [SerializeField] private GameObject _failIndicator;
    
        private readonly List<AssertPrefab> _asserts = new List<AssertPrefab>();

        protected virtual void Setup(string testName)
        {
            _testName.text = testName;
        
            if (_asserts.Any())
            {
                _asserts.ForEach(a => Destroy(a.gameObject));
                _asserts.Clear();
            }
        
            _successIndicator.gameObject.SetActive(false);
            _failIndicator.gameObject.SetActive(false);
        }
    
        protected AssertObject<object> Assert(Func<object> method)
        {
            var prefab = Instantiate(_assertPrefab, _assertsScroll.content).GetComponent<AssertPrefab>();
            prefab.transform.SetSiblingIndex(_asserts.Count);
            _asserts.Add(prefab);
            return prefab.Assert.And(method);
        }

        protected void Finish()
        {
            if (_asserts.All(a => a.Assert.EndResult)) {
                _successIndicator.gameObject.SetActive(true);
            } else {
                _failIndicator.gameObject.SetActive(true);
            }
        }
    }
}