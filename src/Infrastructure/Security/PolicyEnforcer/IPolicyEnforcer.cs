﻿using Domain.Security.Authorizations;
using ErrorOr;
using Infrastructure.Security.CurrentUserProvider;

namespace Infrastructure.Security.PolicyEnforcer;

public interface IPolicyEnforcer
{
    public ErrorOr<Success> Authorize<T>(
        IAuthorizeableRequest<T> request,
        CurrentUser currentUser,
        string policy);
}