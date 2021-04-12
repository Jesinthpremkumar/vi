using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vi.Dtos;
using vi.Models;

namespace vi.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, customer>().ForMember(c => c.id, opt => opt.Ignore()); 
            Mapper.CreateMap<MembershipType, MemberhipTypeDto>();
        }
    }
}