using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace EMR.Models
{
    public class GetUserDetailsRequestModel : IRequest<GetUserDetailsResponseModelResult>
    {
        public string Name { get; set; }

    }
    public class GetUserDetailsResponseModelResult
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Key { get; set; }
    }
    
}