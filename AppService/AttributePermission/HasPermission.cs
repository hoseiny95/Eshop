using App.Domain.Core.Users.Contract.Repositories;
using App.Domain.Core.Users.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.AttributePermission
{
    public class TestAttribute : TypeFilterAttribute
    {


        public TestAttribute(PermissionEnum.Rights[] item) : base(typeof(AuthorizeActionFilter))
        {
            Arguments = new object[] { item };

        }

        public class AuthorizeActionFilter : IAuthorizationFilter
        {
            private readonly PermissionEnum.Rights[] _item;
           
            private readonly IUnitOfWork _unitOfWork;

            public AuthorizeActionFilter(PermissionEnum.Rights[] item, IUnitOfWork unitOfWork)
            {
                _item = item;
            
                _unitOfWork = unitOfWork;
            }
            public async void OnAuthorization(AuthorizationFilterContext context)
            {
                
                var user = ((ClaimsIdentity)context.HttpContext.User.Identity).Claims
                    .Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault();
              
                var RoleList = _unitOfWork.RoleRepository.GetRolesByUserId((Convert.ToInt32(user))).Result;
              
                var perm = new List<Permission>();
                foreach (var role in RoleList)
                {
                    perm.AddRange(await _unitOfWork.RoleRepository.GetPermissionsByRoleId(role.Id, default));

                }
                var _right = _item[0].ToString();
                if (!perm.Any(x => x.Name == _right))
                {
                    var _res = new { status = 401, Message = "Unauthorized Access", Data = "Unauthorized Access" };
                    //context.Result = new JsonResult(_res);
                    context.HttpContext.Response.StatusCode = 401;
                    await context.HttpContext.Response.WriteAsync("_res");
                    return;
                }

            }
        }
    }
}
