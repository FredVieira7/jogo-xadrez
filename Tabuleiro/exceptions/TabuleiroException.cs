using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez.tabuleiro.exceptions
{
    class TabuleiroException : Exception
    {
        public TabuleiroException(string message):base(message)
        {

        }
    }
}
