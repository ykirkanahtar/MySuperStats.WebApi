using BasketballStats.WebApi.Authorization.Enums;
using Microsoft.AspNetCore.Authorization;
using System;

namespace BasketballStats.WebApi.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class PermissionAttribute : AuthorizeAttribute
    {
        public Entity? Entity{ get; set; }
        
        public CustomClaim? CustomClaim { get; set; }

        public Crud? Crud { get; set; }

        public PermissionAttribute(CustomClaim customClaim) : base("Permission")
        {
            CustomClaim = customClaim;
        }

        public PermissionAttribute(Entity entity, Crud crud) : base("Permission")
        {
            Entity = entity;
            Crud = crud;
        }

    }
}
