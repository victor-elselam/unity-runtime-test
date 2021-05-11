using System;
using System.Collections.Generic;
using System.Linq;
using _Tests;
using UnityEngine.Events;

namespace Scripts
{
    public class AssertObject<T> : IAssert
    {
        public readonly UnityEvent<string> OnRun = new UnityEvent<string>();
    
        private readonly List<Func<T>> _methods = new List<Func<T>>();
        private T _expectedResult;
        private bool _resultShouldBeEqual;
        private string _message;
        private string _prefixMessage;

        public bool EndResult { get; private set; }

        /// <summary>
        /// Add new Assert to test
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public AssertObject<T> And(Func<T> method)
        {
            _methods.Add(method);
            return this;
        }

        /// <summary>
        /// Defines the expected result from this test
        /// </summary>
        /// <param name="expectedResult"></param>
        /// <returns></returns>
        public AssertObject<T> ShouldBe(T expectedResult)
        {
            _resultShouldBeEqual = true;
            _expectedResult = expectedResult;
            _prefixMessage = $"Should Be {expectedResult}";
            return this;
        }
    
        /// <summary>
        /// Defines the expected result from this test
        /// </summary>
        /// <param name="expectedResult"></param>
        /// <returns></returns>
        public AssertObject<T> ShouldNotBe(T expectedResult)
        {
            _resultShouldBeEqual = false;
            _expectedResult = expectedResult;
            _prefixMessage = $"Should Not Be {expectedResult}";
            return this;
        }

        /// <summary>
        /// A simple message explaining why this is the expected result
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public AssertObject<T> Because(string message)
        {
            _message = $"{_prefixMessage} - {message}";
            return this;
        }

        /// <summary>
        /// Run all Asserts and compares to the expected result
        /// </summary>
        /// <returns></returns>
        public AssertObject<T> Run()
        {
            var results = new List<T>();
            _methods.ForEach(m => results.Add(m.Invoke()));

            EndResult = _resultShouldBeEqual ? 
                results.All(r => r.Equals(_expectedResult)) : 
                results.All(r => !r.Equals(_expectedResult));
        
            var result = EndResult ? "Success" : "Fail";

            OnRun?.Invoke($"{result} - {_message} - {string.Join(",\n", results)}");
            return this;
        }
    }
}