using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KYC.MVC.Models
{
    public interface IClaim
    {
        String Subject { get; }

        String Key { get; }

        Byte[] Value { get; }
    }
}
