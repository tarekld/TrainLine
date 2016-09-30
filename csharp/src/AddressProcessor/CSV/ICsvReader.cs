using System;

namespace AddressProcessing.CSV
{
    public interface ICsvReader : IDisposable
    {
        string[] ReadLine();
    }
}
