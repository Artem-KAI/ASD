using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace lvl1
{
    public class RegexMatcher
    {
        private readonly Regex _regex;

        public RegexMatcher(string pattern)
        {
            // Ініціалізація скомпільованого регулярного виразу для кращої швидкодії
            _regex = new Regex(pattern, RegexOptions.Compiled);
        }

        /// <summary>
        /// Повертає список слів, які повністю відповідають заданому патерну.
        /// </summary>
        public IEnumerable<string> FindMatchingWords(IEnumerable<string> words)
        {
            return words.Where(word => _regex.IsMatch(word));
        }
    }
}