using AutoMapper;
using Car_Rental.Models;
using Car_Rental.Pages.InputModels;

namespace Car_Rental.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, RegisterInputModel>().ReverseMap();
        CreateMap<User, UserUpdateInputModel>().ReverseMap();
    }
}