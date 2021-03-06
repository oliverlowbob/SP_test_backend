using System.Linq;
using AutoMapper;
using Skoleprotokol.Dtos;
using Skoleprotokol.Models;

namespace Skoleprotokol.Config
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Class, ClassDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Idclass))
                .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.CourseIdcourseNavigation))
                .ReverseMap();

            CreateMap<AttendanceKey, AttendanceKeyDto>()
                .ForMember(dest => dest.LessonUserIdclass, opt => opt.MapFrom(src => src.LessonClassIdclass))
                .ForMember(dest => dest.LessonUserIduser, opt => opt.MapFrom(src => src.LessonUserIduser))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.IdattendanceKey))
                .ReverseMap();

            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Idcourse))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

           CreateMap<Lesson, LessonDto>()
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.ClassIdclassNavigation))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.UserIduserNavigation))
                .ForMember(dest => dest.Present, opt => opt.MapFrom(src => src.Present));

            CreateMap<Role, RoleDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Idrole))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Role1));

            CreateMap<School, SchoolDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Idschool));

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Iduser))
                .ForMember(dest => dest.School, opt => opt.MapFrom(src => src.SchoolIdschoolNavigation))
                .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(src => src.SchoolIdschool))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.RoleIdroleNavigation).ToList()))
                .ForMember(dest => dest.Lessons, opt => opt.MapFrom(src => src.Lessons.Where(l => l.UserIduser == src.Iduser).ToList()))
                .ReverseMap();

            CreateMap<NewUserDto, User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Lastname))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.SchoolIdschool, opt => opt.MapFrom(src => src.SchoolId));
        }
    }
}