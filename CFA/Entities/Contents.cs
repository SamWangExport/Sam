using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Contents
    {
        private readonly int charCount;
        private readonly int score;

        public Contents(int score, int gargabeCharCount)
        {
            this.score = score;
            this.charCount = gargabeCharCount;
        }

        public int CharCount => this.charCount;
        public int Score => this.score;
    }
}

