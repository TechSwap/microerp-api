﻿using MicroErp.Domain.Repository.Orm.Abstract.UnitOfWork;
using MicroErp.Domain.Service.Abstract.Interfaces.Cliente;
using MicroErp.Domain.Service.Abstract.Interfaces.Email;
using MicroErp.Domain.Service.Abstract.Interfaces.Empresa;
using MicroErp.Domain.Service.Abstract.Interfaces.Forncedor;
using MicroErp.Domain.Service.Abstract.Interfaces.Users;
using MicroErp.Domain.Service.Concretes.Clientes;
using MicroErp.Domain.Service.Concretes.Email;
using MicroErp.Domain.Service.Concretes.Empresas;
using MicroErp.Domain.Service.Concretes.Fornecedor;
using MicroErp.Domain.Service.Concretes.Users;
using MicroErp.Infra.Data.Repository.Orm.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using MicroErp.Domain.Service.Abstract.Interfaces.Departamento;
using MicroErp.Domain.Service.Abstract.Interfaces.Funcionario;
using MicroErp.Domain.Service.Abstract.Interfaces.Orcamento;
using MicroErp.Domain.Service.Abstract.Interfaces.OrdemCompra;
using MicroErp.Domain.Service.Abstract.Interfaces.OrdemServico;
using MicroErp.Domain.Service.Abstract.Interfaces.Produto;
using MicroErp.Domain.Service.Abstract.Interfaces.Usuarios;
using MicroErp.Domain.Service.Concretes.Departamento;
using MicroErp.Domain.Service.Concretes.Funcionarios;
using MicroErp.Domain.Service.Concretes.Orcamento;
using MicroErp.Domain.Service.Concretes.OrdemCompra;
using MicroErp.Domain.Service.Concretes.OrdemServico;
using MicroErp.Domain.Service.Concretes.Produtos;
using MicroErp.Domain.Service.Concretes.Usuario;
using Microsoft.AspNetCore.Http;

namespace MicroErp.Infra.Bootstrap.Service;

[ExcludeFromCodeCoverage]
public static class ServiceStartup
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        //Usuarios
        services.AddTransient<IUserService, UserService>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        
        services.AddScoped<IAcessManager, AccessManager>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
        //Clientes
        services.AddScoped<IClienteService, ClienteService>();
        // Empresa
        services.AddScoped<IEmpresaService, EmpresaService>();
        // Fornecedor
        services.AddScoped<IFornecedorService, FornecedorService>();
        // Produto
        services.AddScoped<IProdutoService, ProdutoService>();
        // OrdemServico
        services.AddScoped<IOrdemServicoService, OrdemServicoService>();
        // Departamento
        services.AddScoped<IDepartamentoService, DepartamentoService>();
        // Funcionario
        services.AddScoped<IFuncionarioService, FuncionarioService>();
        // Ordem Compras
        services.AddScoped<IOrdemCompraService, OrdemCompraService>();
        // Usuarios 
        services.AddScoped<IUsuarioService, UsuarioService>();
        // Orcamentos
        services.AddScoped<IOrcamentoService, OrcamentoService>();
        
        return services;
    }
}