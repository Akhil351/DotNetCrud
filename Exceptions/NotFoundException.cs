using System;

namespace Crud.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}