using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.service
{
    [Serializable]
    enum Command
    {
        stop,
        dir,
        up,
        to,
        create,
        remove,
        attrib
    }
}
