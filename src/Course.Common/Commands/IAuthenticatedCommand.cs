using System;

namespace Course.Common.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
         Guid UserId { get; set; }
    }
}