using AutoMapper;
using LojaVirtual.Application.Interfaces;
using LojaVirtual.Application.Mappings;
using LojaVirtual.Application.Services;
using LojaVirtual.Domain.Interfaces.Repositories;
using LojaVirtual.Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Data.Settings;
using Swashbuckle.AspNetCore.Swagger;

namespace LojaVirtual.Services.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();            

            //configurando o gerador de documentação
            //da api através do framework SWAGGER
            services.AddSwaggerGen(
            s =>
            {
                s.SwaggerDoc("v1", 
                    new Info
            {

                Title = "Projeto Controle de Produtos",
                Description = "Sistema de controle de produtos ASP.NET CORE",

                Version = "v1",
                Contact = new Contact

                {
                    Name = "Felipe Mendes",
                    Email = "luizb@id.uff.br",
                    Url = "https://www.linkedin.com/in/feelipemendes/"

                }
            });
            }
            );

            // requires using Microsoft.Extensions.Options
            services.Configure<DatabaseSettings>(
                Configuration.GetSection(nameof(DatabaseSettings)));

            services.AddSingleton<IDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityToViewModel());
                cfg.AddProfile(new ViewModelToEntity());
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            //registrando o swagger
            app.UseSwagger();
            app.UseSwaggerUI(
            s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "e-commerce");
                
            });
            
        }
    }
}
