using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public interface IParseService
    {
        void SetInput(string input);
        ParsingGroup ParseGroup();
        IContents[] ParseContents();
        IContents ParseContent();
        Garbage ParseGarbage();
    }
}
