using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public interface IPosService
    {
        PosService MoveRight();
        void SetInput(string input);
        bool EndOfStream { get; }
        char? Current { get; }
    }
}
