using AutoMapper;
using SysproAssigment.Application.Request.Auth;
using SysproAssigment.Application.Request.Product;
using SysproAssigment.Application.Response.Auth;
using SysproAssigment.Application.Response.Product;
using SysproAssigment.Application.Response.Sales;
using SysproAssigment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Application.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Users, RegisterRequest>().ReverseMap();
            CreateMap<Users, RegisterRespone>().ReverseMap();
            CreateMap<Products, ProductResponse>().ReverseMap();
            CreateMap<AddProductRequest, Products>().ReverseMap();
            CreateMap<Sales, SalesReponse>().ReverseMap();
           
        }
    }
}
