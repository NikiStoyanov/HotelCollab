using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace HotelCollab.Attributes
{
    public class CustomAuthorizeAttribute : Attribute
    {

        public CustomAuthorizeAttribute(ClaimsPrincipal claims,string role)
        {
           var temp= claims.FindFirst("Role");
        }

        
    }
}
