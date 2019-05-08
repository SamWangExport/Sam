using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public class ParseService : IParseService
    {
        private IPosService _pos;

        public ParseService(IPosService parsePosService)
        {
            _pos = parsePosService;
        }

        public void SetInput(string input) { this._pos.SetInput(input); }

        public ParsingGroup ParseGroup()
        {
            if (NextUnignoredChar() != '{')
                throw new Exception("'{' expected");

            var contents = ParseContents();

            if (NextUnignoredChar() != '}')
                throw new Exception("'}' expected");

            return new ParsingGroup(contents);
        }

        public IContents[] ParseContents()
        {
            var list = new List<IContents>();
            while (CurrentChar != '}')
            {
                list.Add(ParseContent());

                if (CurrentChar == '}')
                    break;

                if (NextUnignoredChar() != ',')
                    throw new Exception("',' or '}' expected");
            }

            return list.ToArray();

        }

        public IContents ParseContent()
        {
            if (CurrentChar == '{')
                return ParseGroup();
            if (CurrentChar == '<')
                return ParseGarbage();

            return null;
        }

        public Garbage ParseGarbage()
        {
            if (NextUnignoredChar() != '<')
                throw new Exception("'<' expected");

            var garbage = new List<char>();

            while (true)
            {
                var next = NextUnignoredChar();
                if (next == null)
                    throw new Exception("encountered end of stream while parsing garbage");
                if (next == '>')
                    return new Garbage(new String(garbage.ToArray()));
                garbage.Add(next.Value);

            }
        }

        char? NextUnignoredChar()
        {
            var c = NextChar();
            if (c == '!')
            {
                NextChar();
                return NextUnignoredChar();
            }
            return c;
        }

        char? CurrentChar => _pos.Current;

        char? NextChar()
        {
            var c = _pos.Current;
            _pos = _pos.MoveRight();
            return c;
        }
    }
}
