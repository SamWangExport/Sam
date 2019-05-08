using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Garbage : IContents
    {
        private readonly string _garbage;

        public Garbage(string garbage)
        {
            _garbage = garbage;
        }

        public int CharCount => _garbage.Length;

        public int Score(int outer)
        {
            return 0;
        }
    
    }
}
