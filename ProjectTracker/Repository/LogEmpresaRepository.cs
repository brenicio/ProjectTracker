using Microsoft.EntityFrameworkCore;
using ProjectTracker.Contracts.Repository;
using ProjectTracker.Data;
using ProjectTracker.Models;

namespace ProjectTracker.Repository
{
    public class LogEmpresaRepository : ILogEmpresaRepository
    {
        private readonly BancoContext _bancoContext;
        public LogEmpresaRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public void AddLogEmpresa(LogEmpresa LogEmpresa)
        {
            throw new NotImplementedException();
        }

        public async Task AddLogEmpresaInicio(ProcessoUsuario processo)
        {
            try
            {
                DateTime Data = DateTime.Now;
                var processoIniciado = await _bancoContext.ProcessosUsuario
                     .Where(x => x.IdEmpresa == processo.IdEmpresa)
                     .Where(d => d.Status.Equals("INICIO"))
                     .AsNoTracking()
                     .FirstOrDefaultAsync();

                if(processoIniciado != null)
                {
                    var logEmpresaPausada = await _bancoContext.LogEmpresas
                        .Where(x => x.IdEmpresa == processo.IdEmpresa)
                        .Where(s => s.Status.Equals("PAUSA"))
                        .Where(d => d.DataFim == null)
                        .OrderByDescending(o => o.Id)
                        .FirstOrDefaultAsync();

                    var primeiroLogInicio = await _bancoContext.LogEmpresas
                        .Where(x => x.IdEmpresa == processo.IdEmpresa)
                        .Where(d => d.Status.Equals("INICIO"))
                        .AsNoTracking()
                        .CountAsync();

                    if (logEmpresaPausada != null)
                    {
                        var logPausa = new LogEmpresa();
                        logEmpresaPausada.DataFim = new DateTime(Data.Year, Data.Month, Data.Day, Data.Hour, Data.Minute, Data.Second);
                        logEmpresaPausada.TempoDecorrido = (long?)(logEmpresaPausada.DataFim - logEmpresaPausada.DataInicio).Value.TotalSeconds;
                        _bancoContext.LogEmpresas.Entry(logEmpresaPausada).State = EntityState.Modified;
                        await _bancoContext.SaveChangesAsync();

                        logPausa = await _bancoContext.LogEmpresas
                                                .AsNoTracking()
                                                .Where(x => x.Id == logEmpresaPausada.Id)
                                                .Where(d => d.DataFim != null)
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync();

                        if(logPausa != null)
                        {
                            LogEmpresa logEmpresa = new();
                            logEmpresa.IdEmpresa = processo.IdEmpresa;
                            logEmpresa.Status = "INICIO";
                            logEmpresa.DataCadastro = new DateTime(Data.Year, Data.Month, Data.Day, Data.Hour, Data.Minute, Data.Second);
                            logEmpresa.DataInicio = logPausa.DataFim;

                            _bancoContext.LogEmpresas.Entry(logEmpresa).State = EntityState.Added;
                            await _bancoContext.LogEmpresas.AddAsync(logEmpresa);
                            await _bancoContext.SaveChangesAsync();
                        }
                    }
                    else if(primeiroLogInicio == 0)
                    {
                        LogEmpresa logEmpresa = new();
                        logEmpresa.IdEmpresa = processo.IdEmpresa;
                        logEmpresa.Status = "INICIO";
                        logEmpresa.DataCadastro = new DateTime(Data.Year, Data.Month, Data.Day, Data.Hour, Data.Minute, Data.Second);
                        logEmpresa.DataInicio = processo.DataInicial;

                        _bancoContext.LogEmpresas.Entry(logEmpresa).State = EntityState.Added;
                        await _bancoContext.LogEmpresas.AddAsync(logEmpresa);
                        await _bancoContext.SaveChangesAsync();
                    }
                }

                //TimeSpan? diferencaTempo;
                //LogEmpresa logEmpresa = new();

                //var processoIniciado = await _bancoContext.ProcessosUsuario
                //     .Where(x => x.IdEmpresa == processo.IdEmpresa)
                //     .Where(d => d.Status.Equals("INICIO"))
                //     .FirstOrDefaultAsync();

                //if (processoIniciado == null)
                //{

                //    var logEmpresaPausada = await _bancoContext.LogEmpresas
                //        .Where(x => x.IdEmpresa == processo.IdEmpresa)
                //        .Where(s => s.Status.Equals("PAUSA"))
                //        .Where(d => d.DataFim == null)
                //        .OrderByDescending(o => o.Id)
                //        .FirstOrDefaultAsync();

                //    var logEmpresaIniciada = await _bancoContext.LogEmpresas
                //        .Where(x => x.IdEmpresa == processo.IdEmpresa)
                //        .Where(s => s.Status.Equals("INICIO"))
                //        .Where(d => d.DataFim == null)
                //        .OrderByDescending(o => o.Id)
                //        .FirstOrDefaultAsync();

                //    var empresa = await _bancoContext.Empresas
                //        .Where(x => x.Id == processo.IdEmpresa)
                //        .FirstAsync();

                //    if (logEmpresaPausada != null)
                //    {
                //        logEmpresaPausada.DataFim = DateTime.Now;
                //        logEmpresaPausada.DataFim = logEmpresaPausada.DataFim.Value.AddTicks(-(logEmpresaPausada.DataFim.Value.Ticks % TimeSpan.TicksPerSecond));
                //        diferencaTempo = logEmpresaPausada.DataFim - logEmpresaPausada.DataInicio;
                //        logEmpresaPausada.TempoDecorrido = (long?)diferencaTempo.Value.TotalSeconds;



                //        _bancoContext.LogEmpresas.Entry(logEmpresaPausada).State = EntityState.Modified;
                //        _bancoContext.SaveChanges();

                //        var resultDataFim = await _bancoContext.LogEmpresas
                //                                .AsNoTracking()
                //                                .Where(x => x.Id == logEmpresaPausada.Id)
                //                                .FirstOrDefaultAsync();

                //        DateTime? DataFimLogEmpresaPausado = resultDataFim?.DataFim;

                //        if (DataFimLogEmpresaPausado != null && logEmpresaIniciada == null)
                //        {
                //            logEmpresa.IdEmpresa = processo.IdEmpresa;
                //            logEmpresa.Status = "INICIO";
                //            logEmpresa.DataCadastro = DateTime.Now;
                //            logEmpresa.DataInicio = logEmpresaPausada.DataFim;

                //            _bancoContext.LogEmpresas.Entry(logEmpresa).State = EntityState.Added;
                //            await _bancoContext.LogEmpresas.AddAsync(logEmpresa);
                //            await _bancoContext.SaveChangesAsync();
                //        }

                //    }
                //    else if (logEmpresaIniciada == null)
                //    {
                //        logEmpresa.IdEmpresa = processo.IdEmpresa;
                //        logEmpresa.Status = "INICIO";
                //        logEmpresa.DataCadastro = DateTime.Now;
                //        logEmpresa.DataInicio = processo.DataInicial;

                //        _bancoContext.LogEmpresas.Entry(logEmpresa).State = EntityState.Added;
                //        await _bancoContext.LogEmpresas.AddAsync(logEmpresa);
                //        await _bancoContext.SaveChangesAsync();

                //        if (empresa.DataInicio == null)
                //        {
                //            empresa.DataInicio = processo.DataInicial;
                //            _bancoContext.Empresas.Entry(empresa).State = EntityState.Modified;
                //            await _bancoContext.SaveChangesAsync();
                //        }
                //    }
                //}



                //var processoIniciado = await _bancoContext.ProcessosUsuario
                //    .Where(x => x.IdEmpresa == processo.IdEmpresa)
                //    .Where(d => d.Status.Equals("INICIO"))
                //    .FirstOrDefaultAsync();

                //var logEmpresaPausada = await _bancoContext.LogEmpresas
                //    .Where(x => x.IdEmpresa == processo.IdEmpresa)
                //    .Where(s => s.Status.Equals("PAUSA"))
                //    .Where(d => d.DataFim == null)
                //    .OrderByDescending(o => o.Id)
                //    .FirstOrDefaultAsync();

                //var logEmpresaIniciada = await _bancoContext.LogEmpresas
                //    .Where(x => x.IdEmpresa == processo.IdEmpresa)
                //    .Where(s => s.Status.Equals("INICIO"))
                //    .Where(d => d.DataFim == null)
                //    .OrderByDescending(o => o.Id)
                //    .FirstOrDefaultAsync();

                //var empresa = await _bancoContext.Empresas
                //    .Where(x => x.Id == processo.IdEmpresa)
                //    .FirstAsync();

                //if(empresa.DataInicio == null)
                //{
                //    empresa.DataInicio = processo.DataInicial;
                //    _bancoContext.Empresas.Entry(empresa).State = EntityState.Modified;
                //    _bancoContext.SaveChanges();
                //}

                //if (logEmpresaPausada != null && processoIniciado == null)
                //{
                //    logEmpresaPausada.DataFim = DateTime.Now;
                //    logEmpresaPausada.DataFim = logEmpresaPausada.DataFim.Value.AddTicks(-(logEmpresaPausada.DataFim.Value.Ticks % TimeSpan.TicksPerSecond));
                //    diferencaTempo = logEmpresaPausada.DataFim - logEmpresaPausada.DataInicio;
                //    logEmpresaPausada.TempoDecorrido = (long?)diferencaTempo.Value.TotalSeconds;


                //    logEmpresa.DataInicio = logEmpresaPausada.DataFim;

                //    _bancoContext.LogEmpresas.Entry(logEmpresaPausada).State = EntityState.Modified;
                //    _bancoContext.SaveChanges();
                //}
                //else if (processoIniciado == null)
                //{
                //    logEmpresa.DataInicio = processo.DataInicial;
                //}

                //if (processoIniciado == null && logEmpresaIniciada == null)
                //{
                //    logEmpresa.IdEmpresa = processo.IdEmpresa;
                //    logEmpresa.Status = "INICIO";
                //    logEmpresa.DataCadastro = DateTime.Now;

                //    _bancoContext.LogEmpresas.Entry(logEmpresa).State = EntityState.Added;
                //    _bancoContext.LogEmpresas.Add(logEmpresa);
                //    _bancoContext.SaveChanges();
                //}


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddLogEmpresaPausa(ProcessoUsuario processo)
        {
            try
            {
                var processoIniciado = await _bancoContext.ProcessosUsuario
                    .Where(x => x.IdEmpresa == processo.IdEmpresa)
                    .Where(d => d.Status.Equals("INICIO"))
                    .FirstOrDefaultAsync();

                if(processoIniciado == null)
                {
                    var logEmpresaIniciada = await _bancoContext.LogEmpresas
                        .Where(x => x.IdEmpresa == processo.IdEmpresa)
                        .Where(s => s.Status.Equals("INICIO"))
                        .Where(d => d.DataFim == null)
                        .OrderByDescending(o => o.Id)
                        .FirstOrDefaultAsync();

                    if(logEmpresaIniciada != null)
                    {
                        var logIniciado = new LogEmpresa();
                        logEmpresaIniciada.DataFim = processo.DataMovimento;
                        logEmpresaIniciada.TempoDecorrido = (long?)(logEmpresaIniciada.DataFim - logEmpresaIniciada.DataInicio).Value.TotalSeconds;
                        _bancoContext.LogEmpresas.Entry(logEmpresaIniciada).State = EntityState.Modified;
                        await _bancoContext.SaveChangesAsync();

                        logIniciado = await _bancoContext.LogEmpresas
                                            .Where(x => x.Id == logEmpresaIniciada.Id)
                                            .Where(d => d.DataFim != null)
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync();

                        if(logIniciado != null)
                        {
                            LogEmpresa logEmpresa = new LogEmpresa();
                            logEmpresa.IdEmpresa = processo.IdEmpresa;
                            logEmpresa.Status = "PAUSA";
                            logEmpresa.DataInicio = processo.DataMovimento;
                            logEmpresa.DataCadastro = DateTime.Now;

                            _bancoContext.LogEmpresas.Entry(logEmpresa).State = EntityState.Added;
                            await _bancoContext.LogEmpresas.AddAsync(logEmpresa);
                            await _bancoContext.SaveChangesAsync();
                        }
                    }

                }

                //TimeSpan? diferencaTempo;
                //LogEmpresa logEmpresa = new();

                //var processoIniciado = await _bancoContext.ProcessosUsuario
                //    .Where(x => x.IdEmpresa == processo.IdEmpresa)
                //    .Where(d => d.Status.Equals("INICIO"))
                //    .FirstOrDefaultAsync();

                //if (processoIniciado == null)
                //{
                //    var logEmpresaIniciada = await _bancoContext.LogEmpresas
                //        .Where(x => x.IdEmpresa == processo.IdEmpresa)
                //        .Where(s => s.Status.Equals("INICIO"))
                //        .Where(d => d.DataFim == null)
                //        .OrderByDescending(o => o.Id)
                //        .FirstOrDefaultAsync();

                //    var logEmpresaPausada = _bancoContext.LogEmpresas
                //        .Where(x => x.IdEmpresa == processo.IdEmpresa)
                //        .Where(s => s.Status.Equals("PAUSA"))
                //        .Where(d => d.DataFim == null)
                //        .OrderByDescending(o => o.Id)
                //        .FirstOrDefault();

                //    if (logEmpresaIniciada != null)
                //    {
                //        logEmpresaIniciada.DataFim = processo.DataMovimento;
                //        diferencaTempo = logEmpresaIniciada.DataFim - logEmpresaIniciada.DataInicio;
                //        logEmpresaIniciada.TempoDecorrido = (long?)diferencaTempo.Value.TotalSeconds;

                //        _bancoContext.LogEmpresas.Entry(logEmpresaIniciada).State = EntityState.Modified;
                //        await _bancoContext.SaveChangesAsync();

                //        var resultDataFim = await _bancoContext.LogEmpresas
                //                            .Where(x => x.Id == logEmpresaIniciada.Id)
                //                            .FirstOrDefaultAsync();

                //        DateTime? DataFimLogEmpresaIniciada = resultDataFim?.DataFim;

                //        if (DataFimLogEmpresaIniciada != null && logEmpresaPausada == null)
                //        {
                //            logEmpresa.IdEmpresa = processo.IdEmpresa;
                //            logEmpresa.Status = "PAUSA";
                //            logEmpresa.DataInicio = processo.DataMovimento;
                //            logEmpresa.DataCadastro = DateTime.Now;

                //            _bancoContext.LogEmpresas.Entry(logEmpresa).State = EntityState.Added;
                //            await _bancoContext.LogEmpresas.AddAsync(logEmpresa);
                //            await _bancoContext.SaveChangesAsync();
                //        }
                //    }
                //}

                //var processoIniciado = _bancoContext.ProcessosUsuario
                //    .Where(x => x.IdEmpresa == processo.IdEmpresa)
                //    .Where(d => d.Status.Equals("INICIO"))
                //    .FirstOrDefault();

                //var logEmpresaIniciada = _bancoContext.LogEmpresas
                //    .Where(x => x.IdEmpresa == processo.IdEmpresa)
                //    .Where(s => s.Status.Equals("INICIO"))
                //    .Where(d => d.DataFim == null)
                //    .FirstOrDefault();

                //var logEmpresaPausada = _bancoContext.LogEmpresas
                //    .Where(x => x.IdEmpresa == processo.IdEmpresa)
                //    .Where(s => s.Status.Equals("PAUSA"))
                //    .Where(d => d.DataFim == null)
                //    .FirstOrDefault();

                //if (logEmpresaIniciada != null && processoIniciado == null)
                //{
                //    logEmpresaIniciada.DataFim = processo.DataMovimento;
                //    diferencaTempo = logEmpresaIniciada.DataFim - logEmpresaIniciada.DataInicio;
                //    logEmpresaIniciada.TempoDecorrido = (long?)diferencaTempo.Value.TotalSeconds;

                //    _bancoContext.LogEmpresas.Entry(logEmpresaIniciada).State = EntityState.Modified;
                //    _bancoContext.SaveChanges();
                //}


                //if (processoIniciado == null && logEmpresaPausada == null)
                //{
                //    logEmpresa.IdEmpresa = processo.IdEmpresa;
                //    logEmpresa.Status = "PAUSA";
                //    logEmpresa.DataInicio = processo.DataMovimento;
                //    logEmpresa.DataCadastro = DateTime.Now;

                //    _bancoContext.LogEmpresas.Entry(logEmpresa).State = EntityState.Added;
                //    _bancoContext.LogEmpresas.Add(logEmpresa);
                //    _bancoContext.SaveChanges();
                //}


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateLogEmpresa(LogEmpresa LogEmpresa)
        {
            throw new NotImplementedException();
        }
    }
}
