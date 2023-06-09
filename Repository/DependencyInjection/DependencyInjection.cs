﻿using Quiz.Repository.Infrastructure.Implementation;
using Quiz.Repository.Infrastructure.Interface;
using Quiz.Repository.Services.Implementation;
using Quiz.Repository.Services.Interface;

namespace Quiz.Repository.DependencyInjection
{
    public static class DependencyInjection
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public static void RepositoryRegister(this IServiceCollection services)
        {
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

