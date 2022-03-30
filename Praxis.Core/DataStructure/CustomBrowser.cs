using System;
using System.Collections.Generic;
using System.Text;

namespace Praxis.Core.DataStructure
{
    public class CustomBrowser
    {
        Stack<string> _history;
        Stack<string> _forward;

        public CustomBrowser(string homePage)
        {
            _history = new Stack<string>();
            _forward = new Stack<string>();

            _history.Push(homePage);
        }

        public void VisitingUrl(string pageUri)
        {
            _history.Push(pageUri);
            _forward.Clear();
        }

        public string Back(int stepCount = 1)
        {
            for (int i = 0; i < stepCount; i++)
            {
                if (_history.Count <= 1)
                    break;

                _forward.Push(_history.Peek());
                _history.Pop();
            }

            return _history.Peek();
        }

        public string Forward(int stepCount = 1)
        {
            for (int i = 0; i < stepCount; i++)
            {
                if (_forward.Count <= 0)
                    break;

                _history.Push(_forward.Peek());
                _forward.Pop();
            }

            return _history.Peek();
        }
    }
}
