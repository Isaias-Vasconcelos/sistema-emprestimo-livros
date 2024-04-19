﻿using AutoMapper;
using GerenciamentoEmprestimoLivros.Application.InputModel;
using GerenciamentoEmprestimoLivros.Application.ViewModel;
using GerenciamentoEmprestimoLivros.Core.Entities;

namespace GerenciamentoEmprestimoLivros.Application.Profiles
{
    public class ConfigurationProfile: Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<AdicionarUsuarioInputModel, Usuario>();
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<AtualizarUsuarioInputModel, Usuario>();
        }
    }
}
