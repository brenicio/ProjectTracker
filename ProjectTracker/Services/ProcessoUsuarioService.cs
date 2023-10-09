using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProjectTracker.Contracts.Repository;
using ProjectTracker.Contracts.Services;
using ProjectTracker.Models;
using System.ComponentModel;

namespace ProjectTracker.Services
{
    public class ProcessoUsuarioService : IProcessoUsuarioService
    {
        private readonly IProcessoUsuarioRepository _processoUsuarioRepository;

        public ProcessoUsuarioService(IProcessoUsuarioRepository processoUsuarioRepository)
        {
            _processoUsuarioRepository = processoUsuarioRepository;
        }

        public ProcessoUsuario AddProcessoUsuario(ProcessoUsuario processo)
        {
            if (processo != null)
            {
                var processoUsuario = _processoUsuarioRepository.AddProcessoUsuario(processo);
                return processoUsuario;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void DeleteProcessoUsuario(ProcessoUsuario ProcessoUsuario)
        {
            if(ProcessoUsuario != null && ProcessoUsuario.Status.Equals("NAO INICIADO"))
            {
                _processoUsuarioRepository.DeleteProcessoUsuario(ProcessoUsuario);
            }
        }

        public List<ProcessoUsuario> GetListProcessosUsuario(int IdUsuario)
        {
            if (IdUsuario != 0)
            {
                var processos = _processoUsuarioRepository.GetListProcessosUsuario(IdUsuario).Result;
                return processos;
            }
            else
            {
                return new List<ProcessoUsuario>();
            }
        }

        public List<ProcessoUsuario> GetListProcessosUsuarioFinalizados(int IdUsuario)
        {
            if (IdUsuario != 0)
            {
                var processos = _processoUsuarioRepository.GetListProcessosUsuarioFinalizados(IdUsuario).Result;
                return processos;
            }
            else
            {
                return new List<ProcessoUsuario>();
            }
        }

        public ProcessoUsuario GetProcessoUsuario(int Id)
        {
            try
            {
                var processo = _processoUsuarioRepository.GetProcessoUsuario(Id);
                return processo;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public ProcessoUsuario GetProcessoUsuarioFinalizados(int id)
        {
            try
            {
                var idproc = id;
                var processo = _processoUsuarioRepository.GetProcessoUsuarioFinalizados(id);
                return processo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateProcessoUsuario(ProcessoUsuario ProcessoUsuario)
        {
            if(ProcessoUsuario != null)
            {
                await _processoUsuarioRepository.UpdateProcessoUsuario(ProcessoUsuario);
            }
        }
    }
}
