using System;

namespace Course.Common.Auth
{
    public interface IJwtHandler
    {
        JsonWebToken Create(Guid userId);     
    }
}