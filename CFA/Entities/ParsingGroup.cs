using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ParsingGroup : IContents
    {
        private readonly IContents[] _content;

        public ParsingGroup(IContents[] content)
        {
            _content = content;
        }

        public int CharCount => _content.Sum(c => c.CharCount);

        public int Score(int outer)
        {
            var tLayer = outer + 1;
            var innerSum = _content.Sum(c => c.Score(tLayer));
            return tLayer + innerSum;
        }
    }
}
