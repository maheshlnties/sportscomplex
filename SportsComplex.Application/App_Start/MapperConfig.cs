using AutoMapper;
using SportsComplex.Application.ViewModels;
using SportsComplex.Models;

namespace SportsComplex.Application
{
    public class MapperConfig
    {
        public static IMapper RegisterMappers()
        {
            var configuration=new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeViewModel, Employee>();
                cfg.CreateMap<NewsViewModel, News>();
                cfg.CreateMap<News, NewsViewModel>();
            });
           return configuration.CreateMapper();
        }
    }
}