using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projectUDT_app
{   
    [Serializable]
    class StoppAppException:Exception
    {
        public StoppAppException()
        {
        }

        public StoppAppException(string message)
            : base(message)
        {
        }

        public StoppAppException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}