using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public class PosService : IPosService
    {
        private string _input;
        public void SetInput(string input) {
            this._input = input;
        }
        private int _index = 0;
        public void SetIndex(int index)
        {
            this._index = index;
        
        }

        public PosService()
        { }

        public PosService MoveRight()
        {
            PosService temp = new PosService();
            temp.SetInput(_input);
            temp.SetIndex(_index + 1);
            return temp;
        }

        public bool EndOfStream => _index >= _input.Length;

        public char? Current => !EndOfStream ? _input[_index] : (char?)null;
    }
}
