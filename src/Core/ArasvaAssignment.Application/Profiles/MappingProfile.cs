using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ArasvaAssignment.Application.Dtos.BookDtos;
using ArasvaAssignment.Application.Dtos.BorrowTransactionDtos;
using ArasvaAssignment.Application.Dtos.MemberDtos;
using ArasvaAssignment.Domain.Entities;
using AutoMapper;

namespace ArasvaAssignment.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Book
            CreateMap<Book, BookDto>()
            .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.IsAvailable ? 1 : 0)); 
            CreateMap<AddBookDto, Book>()
                .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.IsAvailable == 1)); 
            CreateMap<UpdateBookDetailsDto, Book>()
                .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.IsAvailable == 1));

            //Member
            CreateMap<Member, MemberDto>()
             .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive ? 1 : 0))
              .ForMember(dest => dest.Password, opt => opt.MapFrom(src => "********"));
            CreateMap<AddMemberDto, Member>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive == 1)); 
            CreateMap<UpdateMemberDto, Member>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive == 1));

            //BorrowTransactions
            CreateMap<BorrowTransactions, BorrowBookDto>().ReverseMap();
            CreateMap<ReturnBookDto, BorrowTransactions>().ReverseMap(); 
        }
    }
}
