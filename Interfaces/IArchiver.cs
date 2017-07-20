using System;

namespace Defroster.Interfaces
{
    public interface IArchiver
    {
        string Name { get; }
        string[] Extensions { get; }

        event EventHandler<int> ProgressChanged;

        void Defrost(string path);
    }
}