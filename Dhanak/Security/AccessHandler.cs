using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace Dhanak.Security
{
    public class AccessRequirement : IAuthorizationRequirement
    {
    }

    public class AccessHandler : AuthorizationHandler<AccessRequirement>
    {

        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, AccessRequirement requirement)
        {
            var user = context.User;

            if (user != null && user.Claims != null)
            {
                var firebaseClaim = user.Claims.FirstOrDefault(c => c.Type == "firebase");
                FireBaseUserInfo.FirebaseUserInfo firebaseUserInfo = null;

                if (firebaseClaim != null && firebaseClaim.Value != null)
                {
                    firebaseUserInfo = JsonConvert.DeserializeObject<FireBaseUserInfo.FirebaseUserInfo>(firebaseClaim.Value);

                    if (firebaseUserInfo != null)
                        Debug.WriteLine(firebaseUserInfo.SignInProvider);

                    // do some custom checks: call context.Succeed() if user is OK
                    context.Succeed(requirement);
                }

            }


        }


    }
}
