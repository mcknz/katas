using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator
{
    public class Calculator
    {
        private bool _hasBracketedCustomDelimiter;
        private bool _hasCustomDelimiter;
        private int _lastBracketPosition;

        public int Add(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                return 0;
            }

            _hasBracketedCustomDelimiter = input.StartsWith("//[");
            _hasCustomDelimiter = input.StartsWith("//") && !_hasBracketedCustomDelimiter;
            _lastBracketPosition = input.LastIndexOf("]");

            return AddStringNumbers(
                GetNumbers(input),
                GetDelimiters(input)
            );
        }

        private int AddStringNumbers(string nums, string[] delimiters)
        {
            int total = 0;

            nums.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(n => total += int.Parse(n) > 1000 ? 0 : int.Parse(n));

            return total;
        }

        private string[] GetDelimiters(string input)
        {
            var delimiters = new List<string>() { ",","\n" };

            if (_hasCustomDelimiter)
            {
                delimiters.Add(input.Substring(2, 1));
            }
            else
            {
                if (_hasBracketedCustomDelimiter)
                {
                    input
                        .Substring(2, _lastBracketPosition - 1)
                        .Replace("][", ",")
                        .Replace("[", "")
                        .Replace("]", "")
                        .Split(',')
                        .ToList()
                        .ForEach(n => delimiters.Add(n));
                }
            }
            
            return delimiters.ToArray();
        }

        private string GetNumbers(string input)
        {
            if (!_hasBracketedCustomDelimiter && !_hasCustomDelimiter)
            {
                return input;
            }

            return _hasBracketedCustomDelimiter
                ? input.Substring(_lastBracketPosition + 1)
                : input.Substring(4);                
        }
    }
}
