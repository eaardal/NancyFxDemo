﻿using Nancy;

namespace NancyFxDemo.Modules
{
    public class LoginModule : NancyModule
    {
        public LoginModule()
        {
            Post["/login"] = p =>
                            {
                                if (Request.Form.Username != "TheUser")
                                    return Response.AsRedirect("/login/unauthorized");
                                return HttpStatusCode.OK;
                            };
        }
    }
}
