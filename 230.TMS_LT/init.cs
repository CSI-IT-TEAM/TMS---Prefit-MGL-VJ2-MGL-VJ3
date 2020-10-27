using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FORM
{
    public class init
    {
        private static string _line, _mline, _lang;

        public string line { get { return _line; } set { _line = value; } }
        public string mline { get { return _mline; } set { _mline = value; } }
        public string lang { get { return _lang; } set { _lang = value; } }
    }
}
