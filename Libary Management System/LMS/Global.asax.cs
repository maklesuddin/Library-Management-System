using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Models;
using Models.ModelView;

namespace LMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            Mapper.Initialize(config =>
            {
                config.CreateMap<BookVm, Book>();
                config.CreateMap<Book, BookVm>();

                config.CreateMap<DepartMentVm, Department>();
                config.CreateMap<Department, DepartMentVm>();

                //config.CreateMap<GenderVm, Gender>();
                //config.CreateMap<Gender, GenderVm>();

                config.CreateMap<LanguageVm, Language>();
                config.CreateMap<Language, LanguageVm>();

                config.CreateMap<LibrarianVm, Librarian>();
                config.CreateMap<Librarian, LibrarianVm>();

                config.CreateMap<StudentVm, Student>();
                config.CreateMap<Student, StudentVm>();

                config.CreateMap<RentalVm, Rental>();
                config.CreateMap<Rental, RentalVm>();

            });
        }
    }

  
}
