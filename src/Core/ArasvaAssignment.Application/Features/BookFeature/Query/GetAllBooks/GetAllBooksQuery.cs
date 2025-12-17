using MediatR;
using ArasvaAssignment.Application.Dtos.BookDtos;
using ArasvaAssignment.Domain.Common;
using System.Collections.Generic;

namespace ArasvaAssignment.Application.Features.BookFeature.Query.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<ApiResponse<IEnumerable<BookDto>>>
    {
        public string? Search { get; set; }
        public int? IsAvailable { get; set; }    

        public GetAllBooksQuery(string? search = null, int? isAvailable = null)
        {
            Search = search;
            IsAvailable = isAvailable;
        }
    }
}
