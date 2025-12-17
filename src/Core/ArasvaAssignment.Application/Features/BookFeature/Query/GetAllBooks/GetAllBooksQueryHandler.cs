using ArasvaAssignment.Application.Contracts.Persistence;
using ArasvaAssignment.Application.Dtos.BookDtos;
using ArasvaAssignment.Domain.Common;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ArasvaAssignment.Application.Features.BookFeature.Query.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, ApiResponse<IEnumerable<BookDto>>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetAllBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<BookDto>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        { 
            bool? isAvailable = request.IsAvailable switch
            {
                1 => true,
                0 => false,
                _ => null
            };

            var books = await _bookRepository.GetAllBookAsync(request.Search, isAvailable);
            var bookDtos = _mapper.Map<IEnumerable<BookDto>>(books);

            return new ApiResponse<IEnumerable<BookDto>>
            {
                Success = true,
                Message = "Books retrieved successfully",
                Data = bookDtos
            };
        }
    }
}
