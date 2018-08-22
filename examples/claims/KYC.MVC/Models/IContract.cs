using System;

namespace KYC.MVC.Models
{
    public interface IContract
    {
		String ABI { get; }
		String Address { get; }
    }
}
