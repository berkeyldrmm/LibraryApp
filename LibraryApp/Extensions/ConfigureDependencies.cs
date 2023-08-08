using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace LibraryApp.Extensions
{
    public static class ConfigureDependenciesExtension
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            //Bağımlılıkların kontrolü (IoC konteynırına eklenmesi) bu extension metotta yapılıp, program.cs'in yükünün azaltılması amaçlanmıştır.

            services.AddScoped<IStudentDal, StudentDal>();
            services.AddScoped<IBookDal, BookDal>();

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IBookService, BookService>();
        }
    }
}
